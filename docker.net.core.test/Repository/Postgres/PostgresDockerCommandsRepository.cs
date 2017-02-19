using System.Collections.Generic;
using System.Threading.Tasks;
using docker.net.core.test.Context;
using docker.net.core.test.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace docker.net.core.test.Repository.Postgres
{
    public class PostgresDockerCommandsRepository : IPostgresDockerCommandsRepository
    {
        private readonly DockerCommandsDbContext _context;
        private readonly ILogger _logger;

        public PostgresDockerCommandsRepository(DockerCommandsDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("DockerCommandsRepository");
        }

        public async Task<List<DockerCommand>> GetDockerCommandsAsync()
        {
            return await _context.DockerCommands.ToListAsync();
        }
    }
}
