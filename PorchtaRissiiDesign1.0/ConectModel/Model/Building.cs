using System.Collections.Generic;


namespace PorchaAPI
{
    public partial class Building
    {
        public Building()
        {
            Apartments = new HashSet<Apartment>();
        }

        public int BuildingId { get; set; }
        public int? DoorwayCount { get; set; }
        public string Discript { get; set; }
        public int? IdRegion { get; set; }
        public string NumberBuilding { get; set; }
        public string Url2Gis { get; set; }

        public virtual Region IdRegionNavigation { get; set; }
        public virtual ICollection<Apartment> Apartments { get; set; }
    }
}
