using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleTrader.WPF.State.Accounts;
using SimpleTrader.WPF.State.Assets;
using SimpleTrader.WPF.State.Authenticators;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.State.StockStore;
using SimpleTrader.WPF.State.UpdateStockStore;
using SimpleTrader.WPF.State.UsersStore;

namespace SimpleTrader.WPF.HostBuilders
{
    public static class AddStoresHostBuilderExtensions
    {
        public static IHostBuilder AddStores(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<INavigator, Navigator>();
                services.AddSingleton<IAuthenticator, Authenticator>();
                services.AddSingleton<IAccountStore, AccountStore>();
                services.AddSingleton<AssetStore>();
                services.AddSingleton<StockStore>();
                services.AddSingleton<UsersStore>();
                services.AddSingleton<UpdateStockStore>();
            });

            return host;
        }
    }
}
