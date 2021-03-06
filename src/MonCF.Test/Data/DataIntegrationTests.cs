﻿using System;
using MonCF.Data;
using MonCF.Contracts.Data;
using System.Collections.Generic;
using Xunit;
using MonCF.Test.Stubs;
using log4net.Appender;
using log4net.Config;

namespace MonCF.Tests.Data
{
    
    public class DataIntegrationTests
    {
        [Fact]        
        public void SaveSimpleData()
        {
            MonCFExampleDataStore dataStore = new MonCFExampleDataStore("mongodb://localhost");

            Guid theID = Guid.NewGuid();

            var simpleData = TestUtils.GetRandomSimpleData();
            simpleData.Id = theID;

            dataStore.SaveSimpleData(simpleData);

            var dataBack = dataStore.GetSimpleData(theID);

            Assert.Equal(simpleData, dataBack);
        }

        [Fact]        
        public void SaveComplexData()
        {
            MonCFExampleDataStore dataStore = new MonCFExampleDataStore("mongodb://localhost");

            Guid theID = Guid.NewGuid();

            var complexData = TestUtils.GetRandomComplexData();
            complexData.Id = theID;

            dataStore.SaveComplexData(complexData);

            var dataBack = dataStore.GetComplexData(theID);

            Assert.Equal(complexData, dataBack);
        }

        [Fact]
        public void SaveComplexSet()
        {
            MonCFExampleDataStore dataStore = new MonCFExampleDataStore("mongodb://localhost");

            List<ComplexData> cds = new List<ComplexData>();

            for (int i = 0; i < 100; i++)
            {
                var complexData = TestUtils.GetRandomComplexData();

                cds.Add(complexData);
            }

            dataStore.SaveComplexDataSet(cds);

            foreach (var cd in cds)
            {
                var retcd = dataStore.GetComplexData(cd.Id);

                Assert.Equal(cd, retcd);
            }
        }
    }
}
