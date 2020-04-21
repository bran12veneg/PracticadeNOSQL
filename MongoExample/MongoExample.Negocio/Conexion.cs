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


        public MongoClient GetMongoClient(string hostName) 
        { 
            string connectionString = string.Format("mongodb+srv://bran:123@cluster0-rirzj.azure.mongodb.net/test?retryWrites=true&w=majority", hostName); 
            return new MongoClient(connectionString);
        }

        public IMongoDatabase GetDatabaseReference(string hostName, string dbName) 
        { 
            MongoClient client = GetMongoClient("mongodb+srv://bran:123@cluster0-rirzj.azure.mongodb.net/test?retryWrites=true&w=majority"); 
            IMongoDatabase database = client.GetDatabase(dbName); 
            return database; 
        }

        public IMongoDatabase CreateDatabase(string hostName, string databaseName, string collectionName) 
        { 
            MongoClient client = GetMongoClient("mongodb+srv://bran:123@cluster0-rirzj.azure.mongodb.net/test?retryWrites=true&w=majority"); 
            IMongoDatabase database = client.GetDatabase(databaseName); 
            database.CreateCollection(collectionName); 
            return database; 
        }
    }
}
