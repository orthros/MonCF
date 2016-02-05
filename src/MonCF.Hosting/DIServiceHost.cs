using MonCF.Data;
using Orth.Core.Logs;
using System;
using System.ServiceModel;

namespace MonCF.Hosting
{
    public class DIServiceHost : ServiceHost
    {
        public DIServiceHost(ILog logger, IMonCFDataStore datastore, Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }
            if (datastore == null)
            {
                throw new ArgumentNullException("datastore");
            }

            foreach (var cd in this.ImplementedContracts.Values)
            {
                cd.ContractBehaviors.Add(new DIInstanceProvider(logger, datastore));
            }

        }
    }
}
