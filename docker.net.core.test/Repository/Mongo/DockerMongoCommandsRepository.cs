using System.Collections.Generic;
using System.Threading.Tasks;
using docker.net.core.test.Models;
using MongoDB.Driver;

namespace docker.net.core.test.Repository.Mongo
{
    public class MongoDockerCommandsRepository : IMongoDockerCommandsRepository
    {
        private readonly DockerCommandsContext _context;

        public MongoDockerCommandsRepository()
        {
            _context = new DockerCommandsContext();
        }
        public Task<List<DockerCommand>> GetDockerCommandsAsync()
        {
            var commands = _context.Commands.Find(_ => true).ToListAsync();
            return commands;
        }
    }
}
