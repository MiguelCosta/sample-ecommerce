namespace Mpc.Ecommerce.BackOffice.Application.Services.Configuration
{
    using Microsoft.Extensions.DependencyInjection;
    using Mpc.Ecommerce.BackOffice.Application.Services.Countries;
    using Mpc.Ecommerce.BackOffice.Application.Services.Security;
    using Mpc.Ecommerce.BackOffice.Application.Services.Users;
    using Mpc.Ecommerce.BackOffice.Infrastructure.CrossCutting.Settings;

    public static class DependenciesConfiguration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<IEncryptText, EncryptTextSha1>();
            services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}
