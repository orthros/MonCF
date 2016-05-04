using MonCF.Data;
using System;
using System.ServiceModel;

namespace MonCF.Hosting
{
    public class DIServiceHost : ServiceHost
    {
        public DIServiceHost(IMonCFDataStore datastore, Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            if (datastore == null)
            {
                throw new ArgumentNullException("datastore");
            }

            foreach (var cd in this.ImplementedContracts.Values)
            {
                cd.ContractBehaviors.Add(new DIInstanceProvider(datastore));
            }

        }
    }
}
