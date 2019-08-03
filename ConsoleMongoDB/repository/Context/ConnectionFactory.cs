using MongoDB.Driver;

namespace ConsoleMongoDB.repository.Context
{
    public class ConnectionFactory
    {
        private readonly string _connectionString;
        public ConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IMongoClient GetClient()
        {
            var client = new MongoClient(_connectionString);

            return client;
        }

        public IMongoDatabase GetDataBase(string databaseName)
        {
            var client = GetClient();
            var database = client.GetDatabase(databaseName);

            return database;
        }
    }
}