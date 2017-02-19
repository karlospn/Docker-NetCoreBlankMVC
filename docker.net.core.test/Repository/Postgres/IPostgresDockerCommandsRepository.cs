using System.Collections.Generic;
using System.Threading.Tasks;
using docker.net.core.test.Models;

namespace docker.net.core.test.Repository.Postgres
{

    public interface IPostgresDockerCommandsRepository
    {
        Task<List<DockerCommand>> GetDockerCommandsAsync();
    }
}