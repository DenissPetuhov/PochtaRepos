using Newtonsoft.Json;
using PochtaRossiiDesign1._0;
using System.Collections.Generic;


namespace PorchaAPI
{
    public partial class Apartment
    {
        public Apartment()
        {
            PaymentHumans = new HashSet<PaymentHuman>();
        }

        public int ApartmentId { get; set; }
        public int Number { get; set; }
        public string VilagerName { get; set; }
        public int? IdStatusBox { get; set; }
        public string Discript { get; set; }
        public int? IdBuilding { get; set; }
       
        public int? IdPhoto { get; set; }
    
        public virtual Building IdBuildingNavigation { get; set; }

        public virtual StatusesBox IdStatusBoxNavigation { get; set; }
  
        public virtual ICollection<PaymentHuman> PaymentHumans { get; set; }
    }
}
