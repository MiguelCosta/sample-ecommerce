﻿namespace Mpc.Ecommerce.BackOffice.DesktopApp.Config
{
    using System.Configuration;
    using System.Windows.Forms;
    using Microsoft.Extensions.DependencyInjection;
    using Mpc.Ecommerce.BackOffice.Application.Services.Configuration;
    using Mpc.Ecommerce.BackOffice.Data.Ef.Configuration;
    using Mpc.Ecommerce.BackOffice.Infrastructure.CrossCutting.Settings;

    public static class IoC
    {
        private static ServiceProvider ServiceProvider = null;

        public static T GetForm<T>() where T : Form
        {
            return ServiceProvider.GetService<T>();
        }

        public static void Init()
        {
            var services = new ServiceCollection();
            RegisterForms(services);

            var appSettings = new AppSettings
            {
                DataBaseSettings = new DataBaseSettings
                {
                    ConnectionString = ConfigurationManager.AppSettings["DataBaseConnectionString"]
                }
            };

            services.ConfigureApplicationServices(appSettings);
            services.ConfigureDataEf(appSettings);

            ServiceProvider = services.BuildServiceProvider();
        }

        private static void RegisterForms(IServiceCollection services)
        {
            services.AddSingleton<FrmMain>();
            services.AddSingleton<Core.FrmLoading>();
            services.AddTransient<Countries.FrmCountries>();
            services.AddTransient<Users.FrmUserEdit>();
        }
    }
}
