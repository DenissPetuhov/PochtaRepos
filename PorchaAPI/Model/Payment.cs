using System;
using System.Collections.Generic;

#nullable disable

namespace PorchaAPI
{
    public partial class Payment
    {
        public int Id { get; set; }
        public int? IdHuman { get; set; }
        public decimal? Amount1 { get; set; }
        public decimal? Amount2 { get; set; }
        public decimal? Amount3 { get; set; }
        public int? CountBillTire1 { get; set; }
        public int? CountBillTire2 { get; set; }
        public int? CountBillTire3 { get; set; }
        public int? CountBillTire4 { get; set; }
        public int? CountBillTire5 { get; set; }
        public int? CountBillTire6 { get; set; }
        public int? CountBillTire7 { get; set; }
        public decimal? CountCoins { get; set; }
        public DateTime? Date { get; set; }
        public decimal? CountAmount { get; set; }

        public virtual PaymentHuman IdHumanNavigation { get; set; }
    }
}
