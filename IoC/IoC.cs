using Application;
using Application.Interfaces;
using DB.Interfaces;
using DB.Repositories;
using Domain.Evaluators;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
    public static class IoC
    {
        public static void ConfigureIoC(this IServiceCollection services)
        {
            services.AddTransient<IDnaEvaluator, DnaEvaluator>();
            services.AddTransient<IDnaValidator, DnaValidator>();

            services.AddTransient<IDnaCondition, ColumnEvaluator>();
            services.AddTransient<IDnaCondition, DiagonalEvaluator>();
            services.AddTransient<IDnaCondition, RowEvaluator>();
            services.AddTransient<IDnaCondition, AntiDiagonalEvaluator>();

            services.AddTransient<IDnaRepository, DnaRepository>();
        }
    }
}
