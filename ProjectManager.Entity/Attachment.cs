using System;
using Newtonsoft.Json;

namespace ProjectManager.Entity
{
    public class Attachment : Abstract.Entity
    {
        public Attachment()
        {
            Id = Guid.NewGuid();
        }


        public string Name { get; set; }
        public string Uri { get; set; }

        [JsonIgnore]
        public Issue Issue { get; set; }
    }
}
