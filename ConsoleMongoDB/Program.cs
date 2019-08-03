using System;
using ConsoleMongoDB.domain;
using ConsoleMongoDB.repository;
using GenFu;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ConsoleMongoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new Repository<Client>("mongodb://localhost:27017", "developerdb05");

            var client = A.New<Client>();
            var clientV2 = A.New<Client>();
            clientV2.Id = client.Id;

            var insertReturn = repository.Insert(client);
            var update = repository.Update(clientV2);
            var getReturn = repository.GetById(clientV2.Id);
            //var deleteReturn = repository.Delete(clientV2);
            var allClients = repository.GetAll();
        }
    }
}
