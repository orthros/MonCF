using ExtCF.ContractExtensions.Factory;
using MonCF.Contracts.Data;
using MonCF.Proxy;
using Orth.Core.Logs;
using System;

namespace MonCF.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            ILog logger = new ConsoleLogger();
            IContractExtensionFactory contractExtensionFactory = new ContractExtensionFactory();

            var proxyFactory = new SimpleDataServiceProxyFactory(logger, contractExtensionFactory);

            var proxy = proxyFactory.GenerateProxy();

            var simpleData = new SimpleData();

            proxy.SaveSimpleData(simpleData);


            Console.ReadLine();
        }
    }
}
