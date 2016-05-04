using System;
using MonCF.Service;
using MonCF.Contracts.Data;
using System.Collections.Generic;
using Orth.Core.Utils;
using MonCF.Test.Stubs;
using Xunit;

namespace MonCF.Tests.Service
{

    public class ServiceIntegrationTests
    {
        [Fact]
        public void ServiceSaveSimple()
        {
            StubDataStore stubDataStore = new StubDataStore();

            SimpleService simpleServiceToTest = new SimpleService(stubDataStore);

            Guid theID = Guid.NewGuid();

            var simpleData = new SimpleData(theID, "test1", 1000);

            simpleServiceToTest.SaveSimpleData(simpleData);

            var dataBack = simpleServiceToTest.GetSimpleData(theID);

            Assert.Equal(simpleData, dataBack);
        }

        [Fact]
        public void ServiceSaveComplex()
        {
            StubDataStore stubDataStore = new StubDataStore();

            SimpleService simpleServiceToTest = new SimpleService(stubDataStore);

            Guid theID = Guid.NewGuid();

            var complexData = TestUtils.GetRandomComplexData(10, 50);
            complexData.Id = theID;

            simpleServiceToTest.SaveComplexData(complexData);

            var dataBack = simpleServiceToTest.GetComplexData(theID);

            Assert.Equal(complexData, dataBack);
        }

        [Fact]
        public void ServiceSaveBulk()
        {
            StubDataStore stubDataStore = new StubDataStore();

            SimpleService simpleServiceToTest = new SimpleService(stubDataStore);

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

                Assert.Equal(cd, retcd);
            }
        }
    }
}
