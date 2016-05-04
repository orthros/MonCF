using log4net;
using MonCF.Data;
using System;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace MonCF.Hosting
{
    public class DIServiceHostFactory : ServiceHostFactory
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(DIServiceHostFactory));

        private IMonCFDataStore DataStore { get; set; }

        public DIServiceHostFactory(IMonCFDataStore datastore) : base()
        {
            if(datastore == null)
            {
                throw new ArgumentNullException(nameof(datastore));
            }

            this.DataStore = datastore;
        }

        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new DIServiceHost(this.DataStore, serviceType, baseAddresses);
        }
    }
}
