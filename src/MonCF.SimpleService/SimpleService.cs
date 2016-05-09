using log4net;
using MonCF.Contracts.Data;
using MonCF.Contracts.Services;
using MonCF.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonCF.Service
{
    public class SimpleService : ISimpleDataService
    {
        protected static readonly ILog Logger = LogManager.GetLogger(typeof(SimpleService));
        
        protected IMonCFDataStore DataStore
        {
            get;
            private set;
        }

        public SimpleService(IMonCFDataStore dataStore)
        {
            if(dataStore == null)
            {
                throw new ArgumentNullException("dataStore");
            }
                        
            this.DataStore = dataStore;
        }

        public void BulkSaveComplexData(List<ComplexData> saveData)
        {
            if(saveData == null)
            {
                throw new ArgumentNullException("saveData");
            }

            if(!saveData.Any())
            {
                throw new ArgumentException("Saving an Empty set of data", "saveData");
            }

            DataStore.SaveComplexDataSet(saveData);
        }

        public ComplexData GetComplexData(Guid dataID)
        {
            return DataStore.GetComplexData(dataID);
        }

        public SimpleData GetSimpleData(Guid dataID)
        {
            return DataStore.GetSimpleData(dataID);
        }

        public void SaveComplexData(ComplexData saveData)
        {
            if(saveData == null)
            {
                throw new ArgumentNullException("saveData");
            }

            DataStore.SaveComplexData(saveData);
        }

        public void SaveSimpleData(SimpleData saveData)
        {
            if(saveData == null)
            {
                throw new ArgumentNullException("saveData");
            }

            DataStore.SaveSimpleData(saveData);
        }
    }
}
