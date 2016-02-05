using ExtCF.ContractExtensions.Factory;
using MonCF.Contracts.Services;
using Orth.Core.Logs;

namespace MonCF.Proxy
{
    public class SimpleDataServiceProxyFactory
    {
        protected ILog Log { get; private set; }

        protected IContractExtensionFactory ContractExtensionFactory { get; private set; }

        public SimpleDataServiceProxyFactory(ILog log, IContractExtensionFactory factory)
        {
            this.Log = log;
            this.ContractExtensionFactory = factory;
        }

        public ISimpleDataService GenerateProxy()
        {
            SimpleDataServiceProxy proxy = new SimpleDataServiceProxy(this.Log);
            this.ContractExtensionFactory.ApplyContractExtensions(proxy.Endpoint);
            return proxy;
        }
    }
}
