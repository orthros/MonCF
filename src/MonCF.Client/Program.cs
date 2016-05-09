using ExtCF.ContractExtensions.Factory;
using log4net;
using MonCF.Contracts.Data;
using MonCF.Proxy;
using System;

namespace MonCF.Client
{
    class Program
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            
            IContractExtensionFactory contractExtensionFactory = new ContractExtensionFactory();

            logger.Debug("Making a Proxy Factory");

            var proxyFactory = new SimpleDataServiceProxyFactory(contractExtensionFactory);

            logger.Debug("Making a proxy");

            var proxy = proxyFactory.GenerateProxy();

            logger.Debug("Making some simple data");

            var simpleData = new SimpleData();

            logger.Debug("Saving some simple data");
            proxy.SaveSimpleData(simpleData);

            logger.Info("Done doing work, press 'Enter' to exit");

            Console.ReadLine();
        }
    }
}
