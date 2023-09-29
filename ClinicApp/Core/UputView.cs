using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Core
{
    public class UputView
    {
        public int Id { get; set; }
        public string ImeDoktoraOpstePrakse { get; set; }
        public string ImePacijenta { get; set; }
        public string TerminPregleda { get; set; }
        public string Opis{ get; set; }
        public string Obavljen{ get; set; }
    }
}
