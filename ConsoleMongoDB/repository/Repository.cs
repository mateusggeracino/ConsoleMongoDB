using System.Collections.Generic;
using ConsoleMongoDB.domain;
using ConsoleMongoDB.repository.Context;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ConsoleMongoDB.repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly IMongoCollection<T> Collection;
        public Repository(string connectionString, string databaseName)
        {
            var connectionFactory = new ConnectionFactory(connectionString);
            Collection = connectionFactory.GetDataBase(databaseName).GetCollection<T>(typeof(T).Name.ToLower());
        }

        public T Insert(T obj)
        {
            Collection.InsertOne(obj);
            return obj;
        }

        public bool Delete(T obj)
        {
            Collection.DeleteOne(Builders<T>.Filter.Eq("Id", obj.Id));
            return true;
        }

        public T Update(T obj)
        {
            var filter = Builders<T>.Filter.Eq("Id", obj.Id);
            Collection.FindOneAndReplace(filter, obj);
            return obj;
        }

        public T GetById(int id)
        {
            var filters = Builders<T>.Filter.Eq("Id", id);
            return Collection.Find(filters).FirstOrDefault(); ;
        }

        public List<T> GetAll()
        {
            return Collection.AsQueryable().ToList();
        }
    }
}