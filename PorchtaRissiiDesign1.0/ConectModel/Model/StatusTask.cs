using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace PorchaAPI
{
    public partial class StatusTask
    {
        public StatusTask()
        {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string StatusTask1 { get; set; }
        [JsonIgnore]
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
