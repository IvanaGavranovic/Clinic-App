using ClinicApp.Core;

namespace ClinicApp.Core
{
    public class PregledView
    {
        public int Id { get; set; }
        public string ImeDoktora { get; set; }
        public int IdDoktora { get; set; }
        public string TerminPregleda { get; set; }
        public int IdTermina { get; set; }
        public string Obavljen { get; set; }
        public string ImePacijenta { get; set; }
        public int forOrder { get; set; }

    }
        
    
}
