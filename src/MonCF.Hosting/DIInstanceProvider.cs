using MonCF.Data;
using MonCF.Service;
using Orth.Core.Logs;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace MonCF.Hosting
{
    public class DIInstanceProvider : IInstanceProvider, IContractBehavior
    {

        public ILog Log { get; set; }

        public IMonCFDataStore DataStore { get; set; }

        public DIInstanceProvider(ILog log, IMonCFDataStore dataStore)
        {
            if (log == null)
            {
                throw new ArgumentNullException("log");
            }

            if (dataStore == null)
            {
                throw new ArgumentNullException("dataStore");
            }

            this.Log = log;
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
            return new SimpleService(Log, DataStore);
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
