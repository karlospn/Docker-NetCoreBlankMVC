using System.Collections.Generic;
using System.Threading.Tasks;
using docker.net.core.test.Models;

namespace docker.net.core.test.Repository
{

    public interface IDockerCommandsRepository
    {
        Task<List<DockerCommand>> GetDockerCommandsAsync();
    }
}