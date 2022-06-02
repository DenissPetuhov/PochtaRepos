using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace PorchaAPI
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string RoleDiscript { get; set; }
        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
    }
}
