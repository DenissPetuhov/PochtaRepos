using System;
using System.Collections.Generic;

#nullable disable

namespace PorchaAPI
{
    public partial class User
    {
        public User()
        {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }
        public int IdRole { get; set; }
        public int? IdRegion { get; set; }
        public int? Age { get; set; }
        public string ResAdress { get; set; }

        public virtual Region IdRegionNavigation { get; set; }
        public virtual Role IdRoleNavigation { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
