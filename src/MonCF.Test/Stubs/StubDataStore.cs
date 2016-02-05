using MonCF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonCF.Contracts.Data;

namespace MonCF.Test.Stubs
{
    public class StubDataStore : IMonCFDataStore
    {

        private HashSet<ComplexData> ComplexData { get; set; }

        private HashSet<SimpleData> SimpleData { get; set; }

        public StubDataStore()
        {
            ComplexData = new HashSet<Contracts.Data.ComplexData>();
            SimpleData = new HashSet<Contracts.Data.SimpleData>();
        }

        public ComplexData GetComplexData(Guid dataID)
        {
            var found = ComplexData.FirstOrDefault(x => x.Id.Equals(dataID));
            return found;
        }

        public SimpleData GetSimpleData(Guid dataID)
        {
            var found = SimpleData.FirstOrDefault(x => x.Id.Equals(dataID));
            return found;
        }

        public void SaveComplexData(ComplexData dataComplex)
        {
            ComplexData.Add(dataComplex);
        }

        public void SaveComplexDataSet(List<ComplexData> setofData)
        {
            ComplexData.UnionWith(setofData);
        }

        public void SaveSimpleData(SimpleData dataSimple)
        {
            SimpleData.Add(dataSimple);
        }
    }
}
