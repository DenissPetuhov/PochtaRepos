using System;
using System.Collections.Generic;

#nullable disable

namespace PorchaAPI
{
    public partial class PhoneBook
    {
        public int Id { get; set; }
        public string NameOrganisation { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Address { get; set; }
        public string Discript { get; set; }
    }
}
