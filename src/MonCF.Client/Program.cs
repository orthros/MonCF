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

            var proxyFactory = new SimpleDataServiceProxyFactory(contractExtensionFactory);

            var proxy = proxyFactory.GenerateProxy();

            var simpleData = new SimpleData();

            proxy.SaveSimpleData(simpleData);


            Console.ReadLine();
        }
    }
}
