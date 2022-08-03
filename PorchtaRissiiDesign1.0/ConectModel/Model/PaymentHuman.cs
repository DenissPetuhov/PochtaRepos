using Newtonsoft.Json;
using PochtaRossiiDesign1._0;
using System;
using System.Collections.Generic;



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
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
