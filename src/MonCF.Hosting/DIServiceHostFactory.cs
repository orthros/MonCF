using MonCF.Data;
using Orth.Core.Logs;
using System;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace MonCF.Hosting
{
    public class DIServiceHostFactory : ServiceHostFactory
    {
        private ILog Logger { get; set; }

        private IMonCFDataStore DataStore { get; set; }

        public DIServiceHostFactory(ILog log, IMonCFDataStore datastore) : base()
        {
            this.Logger = log;
            this.DataStore = datastore;
        }

        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new DIServiceHost(this.Logger, this.DataStore, serviceType, baseAddresses);
        }
    }
}
