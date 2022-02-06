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
    public static class AppServices
    {
        public static IServiceProvider Configure()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IAuthenticator, Authenticator>();
            services.AddSingleton<IErrorHandler, ErrorHandler>();

            services.AddTransient<LoginViewModel>();
            services.AddTransient<RegisterViewModel>();
            services.AddTransient<UserPanelViewModel>();
            services.AddTransient<INavigator, Navigator>();

            services.AddSingleton<MainViewModel>();
            
            services.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            serviceProvider.GetRequiredService<INavigator>().NavigateTo<LoginViewModel>();

            return serviceProvider;
        }
    }
}
