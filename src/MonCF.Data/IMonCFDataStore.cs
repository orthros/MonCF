using System;
using System.Collections.Generic;
using MonCF.Contracts.Data;

namespace MonCF.Data
{
    public interface IMonCFDataStore
    {
        ComplexData GetComplexData(Guid dataID);
        SimpleData GetSimpleData(Guid dataID);
        void SaveComplexData(ComplexData dataComplex);
        void SaveComplexDataSet(List<ComplexData> setofData);
        void SaveSimpleData(SimpleData dataSimple);
    }
}