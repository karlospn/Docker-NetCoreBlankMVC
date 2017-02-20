using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using docker.net.core.test.Models;
using docker.net.core.test.Repository.Redis;
using Microsoft.DotNet.Cli.Utils;
using MongoDB.Driver;

namespace docker.net.core.test.Repository.Mongo
{
    public class MongoDockerCommandsRepository : IMongoDockerCommandsRepository
    {
        private readonly IRedisRepository _redisRepository;
        private readonly DockerCommandsContext _context;

        public MongoDockerCommandsRepository(IRedisRepository redisRepository)
        {
            _redisRepository = redisRepository;
            _context = new DockerCommandsContext();
        }
        public async Task<List<DockerCommand>> GetDockerCommandsAsync()
        {
            var commands = _redisRepository.Get("Commands");
            if (commands == null)
            {
                commands = await _context.Commands.Find(_ => true).ToListAsync();
                _redisRepository.Insert(commands);
            }
            return commands;
        }
    }
}
