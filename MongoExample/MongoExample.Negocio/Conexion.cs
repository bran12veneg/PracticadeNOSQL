using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace MongoExample.Negocio
{
    public class Conexion
    {
        private string _connStr;
        public MongoClient ConnectWithoutAuthentication() 
        {
            _connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            string connectionString = _connStr; 
            MongoClient client = new MongoClient(connectionString);
            return client;
        }

        public MongoClient ConnectWithAuthentication(string dbName = "ecommlight", string userName = "some_user", string password = "pwd", string servername = "localhost", int portnumber = 27017)
        {
            var credentials = MongoCredential.CreateCredential(dbName, userName, password);
            MongoClientSettings clientSettings = new MongoClientSettings()
            {
                Credentials = new[] { credentials
                },
                Server = new MongoServerAddress(servername, portnumber)
            };
            MongoClient client = new MongoClient(clientSettings);
            return client;
        }

        public MongoClient GetMongoClient(string hostName) 
        { 
            string connectionString = string.Format("mongodb://bran:123@cluster0-shard-00-00-rirzj.azure.mongodb.net:27017,cluster0-shard-00-01-rirzj.azure.mongodb.net:27017,cluster0-shard-00-02-rirzj.azure.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true&w=majority", hostName); 
            return new MongoClient(connectionString);
        }

        public IMongoDatabase GetDatabaseReference(string hostName, string dbName) 
        { 
            MongoClient client = GetMongoClient("mongodb://bran:123@cluster0-shard-00-00-rirzj.azure.mongodb.net:27017,cluster0-shard-00-01-rirzj.azure.mongodb.net:27017,cluster0-shard-00-02-rirzj.azure.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true&w=majority"); 
            IMongoDatabase database = client.GetDatabase(dbName); 
            return database; 
        }

        public IMongoDatabase CreateDatabase(string hostName, string databaseName, string collectionName) 
        { 
            MongoClient client = GetMongoClient("mongodb://bran:123@cluster0-shard-00-00-rirzj.azure.mongodb.net:27017,cluster0-shard-00-01-rirzj.azure.mongodb.net:27017,cluster0-shard-00-02-rirzj.azure.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true&w=majority"); 
            IMongoDatabase database = client.GetDatabase(databaseName); 
            database.CreateCollection(collectionName); 
            return database; 
        }
    }
}
