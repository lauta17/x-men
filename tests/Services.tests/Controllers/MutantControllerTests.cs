using Application.Interfaces;
using AutoMoqCore;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services.Controllers;
using Services.Dtos;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Services.Tests.Controllers
{
    public class MutantControllerTests
    {
        private readonly MutantController _mutantController;
        private readonly AutoMoqer _autoMoqer;

        public MutantControllerTests()
        {
            _autoMoqer = new AutoMoqer();
            _mutantController = _autoMoqer.Resolve<MutantController>();
        }

        [Fact]
        public void PostMustReturnOk()
        {
            //ARRANGE
            var dna = new string[]
            {
                "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG"
            };

            var dnaRequest = new DnaRequest
            {
                Dna = dna
            };

            var isMutant = true;

            var mockDnaEvaluator = _autoMoqer.GetMock<IDnaEvaluatorService>();
            mockDnaEvaluator.Setup(x => x.Evaluate(dnaRequest.Dna))
                .Returns(Task.FromResult(isMutant));

            //ACT
            var result = _mutantController.Post(dnaRequest).Result;
            var actionResult = (OkResult)result;

            //ASSERT
            Assert.Equal(actionResult.StatusCode, (int)HttpStatusCode.OK);
        }

        [Fact]
        public void PostMustReturnBadRequest()
        {
            //ARRANGE
            var dna = new string[]
            {
                "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG"
            };

            var dnaRequest = new DnaRequest
            {
                Dna = dna
            };

            var errorMessage = "DnaFormatIsInvalid";

            var mockDnaEvaluator = _autoMoqer.GetMock<IDnaEvaluatorService>();
            mockDnaEvaluator.Setup(x => x.Evaluate(dnaRequest.Dna))
                .Throws(new ArgumentException(errorMessage));

            //ACT
            var result = _mutantController.Post(dnaRequest).Result;
            var actionResult = (BadRequestObjectResult)result;

            //ASSERT
            Assert.Equal(actionResult.StatusCode, (int)HttpStatusCode.BadRequest);
            Assert.Equal(actionResult.Value, errorMessage);
        }

        [Fact]
        public void PostMustReturnInternalServerError()
        {
            //ARRANGE
            var dna = new string[]
            {
                "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG"
            };

            var dnaRequest = new DnaRequest
            {
                Dna = dna
            };

            var errorMessage = "InternalServerError";

            var mockDnaEvaluator = _autoMoqer.GetMock<IDnaEvaluatorService>();
            mockDnaEvaluator.Setup(x => x.Evaluate(dnaRequest.Dna))
                .Throws(new Exception(errorMessage));

            //ACT
            var result = _mutantController.Post(dnaRequest).Result;
            var actionResult = (ObjectResult)result;

            //ASSERT
            Assert.Equal(actionResult.StatusCode, (int)HttpStatusCode.InternalServerError);
            Assert.Equal(actionResult.Value, errorMessage);
        }
    }
}
