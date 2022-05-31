using System;
using System.Collections.Generic;

#nullable disable

namespace PorchaAPI
{
    public partial class StatusesBox
    {
        public StatusesBox()
        {
            Apartments = new HashSet<Apartment>();
        }

        public int Id { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Apartment> Apartments { get; set; }
    }
}
