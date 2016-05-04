using log4net;
using MonCF.Contracts.Data;
using MonCF.Contracts.Services;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace MonCF.Proxy
{
    public class SimpleDataServiceProxy : ClientBase<ISimpleDataService>, ISimpleDataService
    {
        protected ILog Log = LogManager.GetLogger(typeof(SimpleDataServiceProxy));

        public SimpleDataServiceProxy() 
            : base()
        {             
        }

        public void BulkSaveComplexData(List<ComplexData> saveData)
        {
            Channel.BulkSaveComplexData(saveData);
        }

        public ComplexData GetComplexData(Guid dataID)
        {
            return Channel.GetComplexData(dataID);
        }

        public SimpleData GetSimpleData(Guid dataID)
        {
            return Channel.GetSimpleData(dataID);
        }

        public void SaveComplexData(ComplexData saveData)
        {
            Channel.SaveComplexData(saveData);
        }

        public void SaveSimpleData(SimpleData saveData)
        {
            Channel.SaveSimpleData(saveData);
        }
    }
}
