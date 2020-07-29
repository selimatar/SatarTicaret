using System;
using System.Collections.Generic;

namespace SatarTicaret.Models
{
    public partial class Kargo
    {
        public Kargo()
        {
            this.Satis = new List<Sati>();
        }

        public int Id { get; set; }
        public string SirketAdi { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string WebSitesi { get; set; }
        public string EMail { get; set; }
        public virtual ICollection<Sati> Satis { get; set; }
    }
}
