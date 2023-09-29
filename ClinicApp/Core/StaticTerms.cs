//using ClinicApp.Model;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ClinicApp.Core
//{
//    static public class StaticTerms
//    {
//        private static readonly HashSet<string> terms = new HashSet<string>() { "08:00", "09:00", "10:00", "11:00" };

//        public static IEnumerable<string> GetFreeTerms(DateTime selectDate, int doctorId)
//        {
//            HashSet<string> retVal = new HashSet<string>();
//            using (var db = new ClinicDBEntities())
//            {
//                var PregledsOnSelectedDate = db.Pregleds.Where(pregled => pregled.Doktor_opste_prakse_PregledDoktor_opste_prakseDoktor_Id == doctorId).ToList();
//                var selectedTerms = new HashSet<string>();
//                foreach (var pregled in PregledsOnSelectedDate)
//                {
//                    if (pregled.Termin.Date == selectDate.Date)
//                    {
//                        var time = pregled.Termin.ToString("HH:mm");
//                        selectedTerms.Add(time);
//                    }
//                }

//                foreach (var term in terms)
//                {
//                    if (!selectedTerms.Contains(term))
//                        retVal.Add(term);
//                }

//            }
//            return retVal;
//        }
//    }
//}
