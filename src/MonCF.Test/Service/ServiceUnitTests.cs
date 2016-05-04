using MonCF.Contracts.Data;
using MonCF.Service;
using MonCF.Test.Stubs;
using System;
using System.Collections.Generic;
using Xunit;

namespace MonCF.Tests.Service
{
    public class ServiceUnitTests
    {
        [Fact]
        public void TestSaveSimpleData()
        {
            StubDataStore stubDataStore = new StubDataStore();
            SimpleService simpleServiceToTest = new SimpleService(stubDataStore);

            var simpleData = TestUtils.GetRandomSimpleData();

            simpleServiceToTest.SaveSimpleData(simpleData);
        }

        [Fact]
        public void TestNullSaveSimpleData()
        {
            StubDataStore stubDataStore = new StubDataStore();
            SimpleService simpleServiceToTest = new SimpleService(stubDataStore);

            Assert.Throws(typeof(ArgumentNullException), () =>
            {
                simpleServiceToTest.SaveSimpleData(null);
            });
        }

        [Fact]
        public void TestSaveComplexData()
        {
            StubDataStore stubDataStore = new StubDataStore();
            SimpleService simpleServiceToTest = new SimpleService(stubDataStore);

            var complexData = TestUtils.GetRandomComplexData();

            simpleServiceToTest.SaveComplexData(complexData);
        }

        [Fact]
        public void TestNullSaveComplexData()
        {
            StubDataStore stubDataStore = new StubDataStore();
            SimpleService simpleServiceToTest = new SimpleService(stubDataStore);

            Assert.Throws(typeof(ArgumentNullException), () =>
             {
                 simpleServiceToTest.SaveComplexData(null);
             });
        }

        [Fact]
        public void TestSaveComplexDataSet()
        {
            StubDataStore stubDataStore = new StubDataStore();
            SimpleService simpleServiceToTest = new SimpleService(stubDataStore);

            Random r = new Random((int)DateTime.Now.Ticks);
            var total = r.Next(1000);

            List<ComplexData> dataSet = new List<ComplexData>(total);

            for (int i = 0; i < total; i++)
            {
                dataSet.Add(TestUtils.GetRandomComplexData());
            }

            simpleServiceToTest.BulkSaveComplexData(dataSet);
        }

        [Fact]
        public void TestSaveNullComplexDataSet()
        {
            StubDataStore stubDataStore = new StubDataStore();
            SimpleService simpleServiceToTest = new SimpleService(stubDataStore);

            Assert.Throws(typeof(ArgumentNullException), () =>
             {
                 simpleServiceToTest.BulkSaveComplexData(null);
             });
        }

        [Fact]
        public void TestSaveEmptyComplexDataSet()
        {
            StubDataStore stubDataStore = new StubDataStore();
            SimpleService simpleServiceToTest = new SimpleService(stubDataStore);

            List<ComplexData> dataSet = new List<ComplexData>();

            var thrownException = Assert.Throws(typeof(ArgumentException), () =>
             {
                 simpleServiceToTest.BulkSaveComplexData(dataSet);
             });

            Assert.IsType(typeof(ArgumentException), thrownException);
        }
    }
}
