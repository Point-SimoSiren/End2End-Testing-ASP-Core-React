using System;
using System.Collections.Generic;

namespace KurssiBackend.Models
{
    public partial class Kurssit
    {
        public int KurssiId { get; set; }
        public string Nimi { get; set; }
        public int? Laajuus { get; set; }
    }
}
