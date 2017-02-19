using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using docker.net.core.test.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace docker.net.core.test.Repository.Mongo
{
    public class DockerCommandsContext
    {
        private readonly IMongoDatabase _database;
        private readonly string collectionName;

        public DockerCommandsContext()
        {
            var client = new MongoClient("mongodb://mongo:27017");
            _database = client.GetDatabase("myDocker");
            collectionName = "DockerCommands";
        }

        public IMongoCollection<DockerCommand> Commands
        {
            get
            {
                return _database.GetCollection<DockerCommand>(collectionName);
            }
        }
    }
}
