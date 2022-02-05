using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserPanel.MVVM.ViewModel;
using UserPanel.Services;
using System.Diagnostics;

namespace UserPanel.Core
{
    class AppServices
    {
        private IServiceProvider _serviceProvider;

        private static AppServices _instance;
        private static readonly object _instanceLock = new object();

        public static IServiceProvider ServiceProvider => GetInstance()._serviceProvider;

        private AppServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IAuthenticator, Authenticator>();
            services.AddSingleton<IErrorHandler, ErrorHandler>();

            services.AddTransient<LoginViewModel>();
            services.AddTransient<RegisterViewModel>();
            services.AddTransient<UserPanelViewModel>();

            services.AddSingleton<MainViewModel>();
            services.AddSingleton<INavigator>(s => s.GetRequiredService<MainViewModel>());


            services.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });



            _serviceProvider = services.BuildServiceProvider();

            _serviceProvider.GetRequiredService<MainViewModel>().CurrentView = _serviceProvider.GetRequiredService<LoginViewModel>();
        }
        
        private static AppServices GetInstance()
        {
            lock (_instanceLock)
            {
                return _instance ?? (_instance = new AppServices());
            }
        }
    }
}
