using MonCF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading.Tasks;
using ExtCF.ContractExtensions.Factory;
using System.ServiceModel.Activation;
using MonCF.Data;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using log4net;
using ExtCF.Hosting;

namespace MonCF.SimpleServiceHost
{
    class Program
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            ///TODO: MEF out or make in the App.config the connection string for Mongo
            IMonCFDataStore moncfDS = new MonCFExampleDataStore("mongodb://localhost");
            IContractExtensionFactory factory = new ContractExtensionFactory();

            Func<SimpleService> factoryConstructor = () => new SimpleService(moncfDS);

            using (ServiceHost sh = new InjectionServiceHost<SimpleService>(factoryConstructor, typeof(SimpleService)))
            {
                #region Apply extensions
                try
                {
                    foreach (var endpoint in sh.Description.Endpoints)
                    {
                        factory.ApplyContractExtensions(endpoint);
                    }
                }
                catch (Exception e)
                {
                    Logger.Error("Hit an error applying the extensions to the endpoint");
                    Logger.Fatal(e.Message);
                }
                #endregion                

                #region Run
                try
                {
                    sh.Open();

                    Logger.Info("Services are running\nPress 'Enter' to stop them.");
                    Console.ReadLine();

                    sh.Close();
                }
                catch (TimeoutException timeProblem)
                {
                    Logger.Fatal(timeProblem.Message);
                    Console.ReadLine();
                }
                catch (CommunicationException commProblem)
                {
                    Logger.Fatal(commProblem.Message);
                    Console.ReadLine();
                }
                #endregion
            }
        }
        
    }
}
