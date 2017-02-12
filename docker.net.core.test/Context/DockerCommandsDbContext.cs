using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using docker.net.core.test.Models;
using Microsoft.EntityFrameworkCore;

namespace docker.net.core.test.Context
{
    public class DockerCommandsDbContext : DbContext
    {
        public DbSet<DockerCommand> DockerCommands { get; set; }

        public DockerCommandsDbContext(DbContextOptions<DockerCommandsDbContext> options) : base(options) { }
    }
}
