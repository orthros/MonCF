using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonCF.Data;
using MonCF.Tests.Stubs;
using MonCF.Contracts.Data;
using System.Collections.Generic;

namespace MonCF.Tests.Data
{
    [TestClass]
    public class DataIntegrationTests
    {
        StorageLogger logger;
        MonCFExampleDataStore dataStore;

        [TestInitialize]
        public void Arrange()
        {
            logger = new StorageLogger();
            dataStore = new MonCFExampleDataStore(logger, "mongodb://localhost");
        }

        [TestCleanup]
        public void Cleanup()
        {
            dataStore = null;
            logger = null;
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void SaveSimpleData()
        {            
            Guid theID = Guid.NewGuid();

            var simpleData = TestUtils.GetRandomSimpleData();
            simpleData.Id = theID;

            dataStore.SaveSimpleData(simpleData);

            var dataBack = dataStore.GetSimpleData(theID);

            Assert.AreEqual(simpleData, dataBack);
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void SaveComplexData()
        {            
            Guid theID = Guid.NewGuid();

            var complexData = TestUtils.GetRandomComplexData();
            complexData.Id = theID;

            dataStore.SaveComplexData(complexData);

            var dataBack = dataStore.GetComplexData(theID);

            Assert.AreEqual(complexData, dataBack);
        }        

        [TestMethod]
        [TestCategory("Integration")]
        public void SaveComplexSet()
        {            
            List<ComplexData> cds = new List<ComplexData>();

            for(int i =0; i < 100; i++)
            {                
                var complexData = TestUtils.GetRandomComplexData();

                cds.Add(complexData);
            }

            dataStore.SaveComplexDataSet(cds);

            foreach(var cd in cds)
            {
                var retcd = dataStore.GetComplexData(cd.Id);

                Assert.AreEqual(cd, retcd);
            }            
        }



    }
}
