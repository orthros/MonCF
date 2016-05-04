using ExtCF.ContractExtensions.Factory;
using log4net;
using MonCF.Contracts.Services;


namespace MonCF.Proxy
{
    public class SimpleDataServiceProxyFactory
    {
        protected static readonly ILog Log = LogManager.GetLogger(typeof(SimpleDataServiceProxyFactory));

        protected IContractExtensionFactory ContractExtensionFactory { get; private set; }

        public SimpleDataServiceProxyFactory(IContractExtensionFactory factory)
        {            
            this.ContractExtensionFactory = factory;
        }

        public ISimpleDataService GenerateProxy()
        {
            SimpleDataServiceProxy proxy = new SimpleDataServiceProxy();
            this.ContractExtensionFactory.ApplyContractExtensions(proxy.Endpoint);
            return proxy;
        }
    }
}
