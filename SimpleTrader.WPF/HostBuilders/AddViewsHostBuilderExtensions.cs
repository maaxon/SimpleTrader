using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleTrader.WPF.ViewModels;
using Wpf.Ui;

namespace SimpleTrader.WPF.HostBuilders
{
    public static class AddViewsHostBuilderExtensions
    {
        public static IHostBuilder AddViews(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>(),s.GetRequiredService<ISnackbarService>(),s.GetRequiredService<IContentDialogService>()));
            });

            return host;
        }
    }
}
