using Microsoft.Extensions.Options;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using NethereumExplorer.Core.Model;
using NethereumExplorer.ViewModels;

namespace NethereumExplorer.Services
{
    public class Web3ProviderService : IWeb3ProviderService
    {
        private readonly NetworkConfigurationModel _networkConfigurationModel;

        public Web3ProviderService(IOptions<NetworkConfigurationModel> networkConfigurationModel)
        {
            _networkConfigurationModel = networkConfigurationModel.Value;
            CurrentUrl = _networkConfigurationModel.Url;
        }

        public string CurrentUrl { get; set; }

        //TODO: Simple chainId workaround, this should be the ChainId from the connection, when adding the url we should get the chainId using rpc and add it here.
        public string ChainId => _networkConfigurationModel.ChainId;

        public Web3 GetWeb3()
        {
            if (Utils.IsValidUrl(CurrentUrl))
            {
                return new Web3(CurrentUrl);
            }

            return null;
        }

        public Web3 GetWeb3(Account account)
        {
            if (Utils.IsValidUrl(CurrentUrl))
            {
                return new Web3(account, CurrentUrl);
            }

            return null;
        }
    }
}
