using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace docker.net.core.test.Models
{
    [DataContract(Name = "DockerCommand")]
    public class DockerCommand
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }
        [DataMember(Name = "Name")]
        public string Name { get; set; }
        [DataMember(Name = "Description")]
        public string Description { get; set; }
    }
}
