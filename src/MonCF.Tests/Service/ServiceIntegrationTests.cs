using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonCF.Service;
using MonCF.Tests.Stubs;
using MonCF.Contracts.Data;
using System.Collections.Generic;
using Orth.Core.Utils;

namespace MonCF.Tests.Service
{
    [TestClass]
    public class ServiceIntegrationTests
    {
        StorageLogger storageLogger;
        StubDataStore stubDataStore;

        SimpleService simpleServiceToTest;


        [TestInitialize]
        public void Arrange()
        {
            storageLogger = new StorageLogger();
            stubDataStore = new StubDataStore();

            simpleServiceToTest = new SimpleService(storageLogger, stubDataStore);
        }

        [TestCleanup]
        public void Cleanup()
        {
            simpleServiceToTest = null;
            storageLogger = null;
            stubDataStore = null;
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void ServiceSaveSimple()
        {            
            Guid theID = Guid.NewGuid();

            var simpleData = new SimpleData(theID, "test1", 1000);

            simpleServiceToTest.SaveSimpleData(simpleData);

            var dataBack = simpleServiceToTest.GetSimpleData(theID);

            Assert.AreEqual(simpleData, dataBack);
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void ServiceSaveComplex()
        {          
            Guid theID = Guid.NewGuid();

            var complexData = TestUtils.GetRandomComplexData(10,50);
            complexData.Id = theID;

            simpleServiceToTest.SaveComplexData(complexData);

            var dataBack = simpleServiceToTest.GetComplexData(theID);

            Assert.AreEqual(complexData, dataBack);
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void ServiceSaveBulk()
        {            
            List<ComplexData> cds = new List<ComplexData>();

            for (int i = 0; i < 100; i++)
            {
                Guid theID = Guid.NewGuid();

                string randomName = Utilities.RandomString(10);

                var complexData = new ComplexData(theID, randomName, new List<SubitemData>() { }, ComplexDataTypeEnum.Complex);

                cds.Add(complexData);
            }

            simpleServiceToTest.BulkSaveComplexData(cds);

            foreach (var cd in cds)
            {
                var retcd = simpleServiceToTest.GetComplexData(cd.Id);

                Assert.AreEqual(cd, retcd);
            }
        }
    }
}
