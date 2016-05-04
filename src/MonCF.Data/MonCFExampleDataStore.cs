using log4net;
using MonCF.Contracts.Data;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;

namespace MonCF.Data
{
    public class MonCFExampleDataStore : IMonCFDataStore
    {
        private string ConnectionString { get; set; }
        private static readonly ILog Logger = LogManager.GetLogger(typeof(MonCFExampleDataStore));

        /// TODO: Make these variables configurable and be DI'd into this object        
        private readonly string dataBaseName = "moncfExampleDataBase";
        private readonly string simpleCollectionName = "simpleDataSets";
        private readonly string complexCollectionName = "complexDataSets";

        public MonCFExampleDataStore(string connectionString)
        {
            this.ConnectionString = connectionString;            
        }

        public ComplexData GetComplexData(Guid dataID)
        {
            var client = new MongoClient(ConnectionString);
            var server = client.GetServer();
            var database = server.GetDatabase(dataBaseName);
            var collection = database.GetCollection<ComplexData>(complexCollectionName);

            var quer = Query<ComplexData>.EQ(e => e.Id, dataID);
            var foundOne = collection.FindOne(quer);

            return foundOne;
        }

        public void SaveComplexData(ComplexData dataComplex)
        {
            var client = new MongoClient(ConnectionString);
            var server = client.GetServer();
            var database = server.GetDatabase(dataBaseName);
            var collection = database.GetCollection<ComplexData>(complexCollectionName);
            collection.Insert(dataComplex);            
        }

        public void SaveComplexDataSet(List<ComplexData> setofData)
        {
            var client = new MongoClient(ConnectionString);
            var server = client.GetServer();
            var database = server.GetDatabase(dataBaseName);
            var collection = database.GetCollection<ComplexData>(complexCollectionName);

            collection.InsertBatch(setofData);
        }

        public SimpleData GetSimpleData(Guid dataID)
        {
            var client = new MongoClient(ConnectionString);
            var server = client.GetServer();
            var database = server.GetDatabase(dataBaseName);
            var collection = database.GetCollection<SimpleData>(simpleCollectionName);

            var quer = Query<SimpleData>.EQ(e => e.Id, dataID);
            var foundOne = collection.FindOne(quer);

            return foundOne;
        }

        public void SaveSimpleData(SimpleData dataSimple)
        {
            var client = new MongoClient(ConnectionString);
            var server = client.GetServer();
            var database = server.GetDatabase(dataBaseName);
            var collection = database.GetCollection<SimpleData>(simpleCollectionName);
            collection.Insert(dataSimple);
        }


    }
}
