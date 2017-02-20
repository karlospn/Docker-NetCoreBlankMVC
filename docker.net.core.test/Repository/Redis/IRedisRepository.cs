using System.Collections.Generic;
using docker.net.core.test.Models;

namespace docker.net.core.test.Repository.Redis
{
    public interface IRedisRepository
    {
        List<DockerCommand> Get(string key);
        void Insert(List<DockerCommand> command);
    }
}
