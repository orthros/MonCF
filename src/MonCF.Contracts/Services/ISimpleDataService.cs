using MonCF.Contracts.Data;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace MonCF.Contracts.Services
{
    [ServiceContract]
    public interface ISimpleDataService
    {
        [OperationContract]
        ComplexData GetComplexData(Guid dataID);

        [OperationContract]
        void SaveComplexData(ComplexData saveData);

        [OperationContract]
        SimpleData GetSimpleData(Guid dataID);

        [OperationContract]
        void SaveSimpleData(SimpleData saveData);

        [OperationContract]
        void BulkSaveComplexData(List<ComplexData> saveData);
    }
}
