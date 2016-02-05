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
using MonCF.Hosting;
using Orth.Core.Logs;

namespace MonCF.SimpleServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ///TODO: MEF out or make in the App.config the connection string for Mongo
            ILog logger = new ConsoleLogger();
            IMonCFDataStore moncfDS = new MonCFExampleDataStore(logger, "mongodb://localhost");
            IContractExtensionFactory factory = new ContractExtensionFactory();

            using (ServiceHost sh = new DIServiceHost(logger, moncfDS, typeof(SimpleService)))
            {
                //TODO: Put this into the Di'service host 

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
                    Console.WriteLine("Hit an error applying the extensions to the endpoint");
                    Console.WriteLine(e.Message);
                }
                #endregion                

                #region Run
                try
                {
                    sh.Open();

                    Console.WriteLine("Services are running\nPress 'Enter' to stop them.");
                    Console.ReadLine();

                    sh.Close();
                }
                catch (TimeoutException timeProblem)
                {
                    Console.WriteLine(timeProblem.Message);
                    Console.ReadLine();
                }
                catch (CommunicationException commProblem)
                {
                    Console.WriteLine(commProblem.Message);
                    Console.ReadLine();
                }
                #endregion
            }
        }
        
    }
}
