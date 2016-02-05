using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonCF.Contracts.Data;
using MonCF.Service;
using MonCF.Tests.Stubs;
using System;
using System.Collections.Generic;

namespace MonCF.Tests.Service
{
    [TestClass]
    public class ServiceUnitTests
    {
        StorageLogger storageLogger;
        StubDataStore stubDataStore;

        /// <summary>
        /// This is what we're testing!
        /// </summary>
        SimpleService simpleServiceToTest;

        [TestInitialize]
        public void Arrange()
        {
            storageLogger = new StorageLogger();
            stubDataStore = new StubDataStore();
            simpleServiceToTest = new SimpleService(storageLogger,stubDataStore);
        }

        [TestCleanup]
        public void Cleanup()
        {
            simpleServiceToTest = null;
            stubDataStore = null;
            storageLogger = null;
        }

        [TestMethod]
        [TestCategory("SimpleData")]
        public void TestSaveSimpleData()
        {            
            var simpleData = TestUtils.GetRandomSimpleData();

            simpleServiceToTest.SaveSimpleData(simpleData);
        }

        [TestMethod]
        [TestCategory("SimpleData")]
        [ExpectedException(typeof(ArgumentNullException), "Simple Service should throw an exception when null saves are passed")]
        public void TestNullSaveSimpleData()
        {
            simpleServiceToTest.SaveSimpleData(null);
        }

        [TestMethod]
        [TestCategory("ComplexData")]
        public void TestSaveComplexData()
        {
            var complexData = TestUtils.GetRandomComplexData();

            simpleServiceToTest.SaveComplexData(complexData);
        }

        [TestMethod]
        [TestCategory("ComplexData")]
        [ExpectedException(typeof(ArgumentNullException), "Simple Service should throw an exception when null saves are passed")]
        public void TestNullSaveComplexData()
        {            
            simpleServiceToTest.SaveComplexData(null);
        }

        [TestMethod]
        [TestCategory("ComplexData")]
        public void TestSaveComplexDataSet()
        {            
            Random r = new Random((int)DateTime.Now.Ticks);
            var total = r.Next(1000);

            List<ComplexData> dataSet = new List<ComplexData>(total);

            for(int i =0; i < total; i++)
            {
                dataSet.Add(TestUtils.GetRandomComplexData());
            }

            simpleServiceToTest.BulkSaveComplexData(dataSet);
        }

        [TestMethod]
        [TestCategory("ComplexData")]
        [ExpectedException(typeof(ArgumentNullException), "Simple Service should throw an exception when null saves are passed")]
        public void TestSaveNullComplexDataSet()
        {            
            simpleServiceToTest.BulkSaveComplexData(null);
        }

        [TestMethod]
        [TestCategory("ComplexData")]
        [ExpectedException(typeof(ArgumentException), "Simple Service should throw an exception when null saves are passed")]
        public void TestSaveEmptyComplexDataSet()
        {           
            List<ComplexData> dataSet = new List<ComplexData>();

            simpleServiceToTest.BulkSaveComplexData(dataSet);
        }



    }
}
