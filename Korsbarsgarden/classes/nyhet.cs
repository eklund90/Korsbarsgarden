using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Korsbarsgarden
{
    public class nyhet
    {
        public int id { get; set; }
        public string rubrik { get; set; }
        public string text { get; set; }
        public string skrivenav { get; set; }
        public DateTime datum { get; set; }
        public string fil { get; set; }
        public string bild { get; set; }
    }
}