using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public virtual ICollection<Apartment> Apartments { get; set; }
    }
}
