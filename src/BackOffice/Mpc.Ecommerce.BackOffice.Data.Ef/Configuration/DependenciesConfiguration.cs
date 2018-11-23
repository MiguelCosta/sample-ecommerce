namespace Mpc.Ecommerce.BackOffice.Data.Ef.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Mpc.Ecommerce.BackOffice.Data.Ef;
    using Mpc.Ecommerce.BackOffice.Data.Ef.Repositories;
    using Mpc.Ecommerce.BackOffice.Domain.Core;
    using Mpc.Ecommerce.BackOffice.Domain.Core.Repositories;
    using Mpc.Ecommerce.BackOffice.Infrastructure.CrossCutting.Settings;

    public static class DependenciesConfiguration
    {
        public static IServiceCollection ConfigureDataEf(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(appSettings.DataBaseSettings.ConnectionString));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<ICountriesRepository, CountriesRepository>();

            return services;
        }
    }
}
