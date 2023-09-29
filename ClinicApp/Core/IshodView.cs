using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Core
{
    public class IshodView
    {
        public int Id { get; set; }
        public string ImeDoktora { get; set; }
        public string TerminPregleda { get; set; }
        public string Opis { get; set; }
        public string Dijagnoza { get; set; }
        public int forOrder { get; set; }
    }
}
