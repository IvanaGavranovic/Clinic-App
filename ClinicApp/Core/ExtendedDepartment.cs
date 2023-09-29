using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace ClinicApp.Core
{
    public class ExtendedDepartment
    {
        private int departmanId;
        private string name;
        private string floor;
        private string clinicName;

        public ExtendedDepartment() { }

        public ExtendedDepartment(string name, string floor, string clinicName)
        {
            this.name = name;
            this.floor = floor;
            this.clinicName = clinicName;
        }

        public int DepartmanId
        {
            get
            {
                return departmanId;
            }
            set
            {
                departmanId = value;
            }
        }

        public string Name
        {
            get {
                return name;
            }
            set {
                name = value;
            }
        }

        public string Floor
        {
            get
            {
                return floor;
            }
            set
            {
                floor = value;
            }
        }

        public string ClinicName
        {
            get
            {
                return clinicName;
            }
            set
            {
                clinicName = value;
            }
        }


    }

    public class ExtendedOutcome
    {
        public int Ishod_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Patient { get; set; }
        public string Doctor { get; set; }
        public string Outcome { get; set; }
    }
    public class ExtendedPatient
    {
        public int Pacijent_Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }

    }
}
