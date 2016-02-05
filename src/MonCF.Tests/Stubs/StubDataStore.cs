using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonCF.Contracts.Data;
using MonCF.Data;

namespace MonCF.Tests.Stubs
{
    class StubDataStore : IMonCFDataStore
    {
        HashSet<ComplexData> ComplexDataSet;

        HashSet<SimpleData> SimpleDataSet;

        public StubDataStore()
        {
            this.ComplexDataSet = new HashSet<ComplexData>();
            this.SimpleDataSet = new HashSet<SimpleData>();
        }

        public ComplexData GetComplexData(Guid dataID)
        {
            var find = ComplexDataSet.FirstOrDefault(x => x.Id == dataID);
            return find;
        }

        public SimpleData GetSimpleData(Guid dataID)
        {
            var find = SimpleDataSet.FirstOrDefault(x => x.Id == dataID);
            return find;
        }

        public void SaveComplexData(ComplexData dataComplex)
        {
            ComplexDataSet.Add(dataComplex);
        }

        public void SaveComplexDataSet(List<ComplexData> setofData)
        {
            ComplexDataSet.UnionWith(setofData);
        }

        public void SaveSimpleData(SimpleData dataSimple)
        {
            SimpleDataSet.Add(dataSimple);
        }
    }
}
