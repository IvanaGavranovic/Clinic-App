//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClinicApp.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pregled
    {
        public int Id { get; set; }
        public string Opis { get; set; }
        public string Obvljen { get; set; }
    
        public virtual Termin Termins { get; set; }
        public virtual Pacijent Pacijent { get; set; }
        public virtual Doktor Doktor { get; set; }
        public virtual Ishod_Pregleda Ishod_Pregleda { get; set; }
    }
}
