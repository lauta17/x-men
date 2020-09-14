using AutoMoqCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace IoC.Tests
{
    public class IoCTests
    {
        private readonly AutoMoqer _autoMoqer;

        public IoCTests()
        {
            _autoMoqer = new AutoMoqer();
        }

        [Fact]
        public void ConfigureIoC()
        {
            //ARRANGE
            var servicesCount = 10;
            var service = new ServiceCollection();

            //ACT
            IoC.ConfigureIoC(service);

            //ASSERT
            Assert.Equal(servicesCount, service.Count);
        }
    }
}
