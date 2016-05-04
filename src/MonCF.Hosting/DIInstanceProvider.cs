using log4net;
using MonCF.Data;
using MonCF.Service;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace MonCF.Hosting
{
    public class DIInstanceProvider : IInstanceProvider, IContractBehavior
    {

        protected static readonly ILog Log = LogManager.GetLogger(typeof(DIInstanceProvider));

        public IMonCFDataStore DataStore { get; set; }

        public DIInstanceProvider(IMonCFDataStore dataStore)
        {
            if (dataStore == null)
            {
                throw new ArgumentNullException("dataStore");
            }
                        
            this.DataStore = dataStore;
        }

        #region IContractBehavior Methods
        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }

        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            dispatchRuntime.InstanceProvider = this;
        }

        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
        }
        #endregion

        #region IInstanceProvider
        public object GetInstance(InstanceContext instanceContext)
        {
            return new SimpleService(DataStore);
        }

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return this.GetInstance(instanceContext);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            var disposable = instance as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }

        #endregion
    }
}
