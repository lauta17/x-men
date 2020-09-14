using Application;
using Application.Interfaces;
using DB;
using DB.Interfaces;
using DB.Repositories;
using Domain.Builders;
using Domain.Evaluators;
using Domain.Evaluators.Dna;
using Domain.Factories;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
    public static class IoC
    {
        public static void ConfigureIoC(this IServiceCollection services)
        {
            #region Application

            services.AddTransient<IDnaEvaluatorService, DnaEvaluatorService>();

            #endregion

            #region Domain

            services.AddTransient<IDnaFactory, DnaFactory>();
            services.AddTransient<IDnaBuilder, DnaBuilder>();
            services.AddTransient<IDnaEvaluator, DnaEvaluator>();

            services.AddTransient<IDnaCondition, ColumnEvaluator>();
            services.AddTransient<IDnaCondition, DiagonalEvaluator>();
            services.AddTransient<IDnaCondition, RowEvaluator>();
            services.AddTransient<IDnaCondition, AntiDiagonalEvaluator>();

            #endregion

            #region DB

            services.AddTransient<IDbContext, DbContext>();
            services.AddTransient<IDnaRepository, DnaRepository>();

            #endregion
        }
    }
}
