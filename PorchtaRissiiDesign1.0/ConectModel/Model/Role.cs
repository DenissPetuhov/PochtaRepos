
using System.Collections.Generic;



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

        public virtual ICollection<User> Users { get; set; }
    }
}
