using System.Collections.Generic;
using System.Text;
using docker.net.core.test.Models;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace docker.net.core.test.Repository.Redis
{
    public class RedisRepository : IRedisRepository
    {
        readonly IDistributedCache _memoryCache;
        public RedisRepository(IDistributedCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void Insert(List<DockerCommand> commands)
        {
            var obj = JsonConvert.SerializeObject(commands);
            _memoryCache.Set("Commands", Encoding.UTF8.GetBytes(obj));    
        }

        public List<DockerCommand> Get(string key)
        {
            var cache_key = _memoryCache.Get(key);
            if (cache_key != null)
            {
                dynamic obj = JsonConvert.DeserializeObject<dynamic>(Encoding.UTF8.GetString(cache_key));

                var dockerList = new List<DockerCommand>();
                for (var i = 0; i < obj.Count; i++)
                {
                    dockerList.Add(new DockerCommand
                    {
                            Id = obj[i]["Id"],
                            Name = obj[i]["Name"],
                            Description = obj[i]["Description"]                     
                    });
                }
          
            }
            return null;
        }



    }
}
