using MonCF.Contracts.Data;
using MonCF.Contracts.Services;
using MonCF.Data;
using Orth.Core.Logs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonCF.Service
{
    public class SimpleService : ISimpleDataService
    {
        protected ILog Logger
        {
            get;
            private set;
        }
        
        protected IMonCFDataStore DataStore
        {
            get;
            private set;
        }

        public SimpleService(ILog logger, IMonCFDataStore dataStore)
        {
            if(logger == null)
            {
                throw new ArgumentNullException("logger");
            }

            if(dataStore == null)
            {
                throw new ArgumentNullException("dataStore");
            }

            this.Logger = logger;
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
                throw new ArgumentException("Saving an Empty set of data to save", "saveData");
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
