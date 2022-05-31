using System;
using System.Collections.Generic;

#nullable disable

namespace PorchaAPI
{
    public partial class Task
    {
        public int Id { get; set; }
        public string TextTask { get; set; }
        public DateTime? DateTask { get; set; }
        public int? Priority { get; set; }
        public int? IdPostman { get; set; }

        public virtual User IdPostmanNavigation { get; set; }
    }
}
