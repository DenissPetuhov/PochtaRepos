using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace PorchaAPI
{
    public partial class PaymentHuman
    {
        public PaymentHuman()
        {
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? IdApartament { get; set; }
        public string Discript { get; set; }
        public DateTime? PayDate { get; set; }
        public string PhoneNumber { get; set; }

      
        public virtual Apartment IdApartamentNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
