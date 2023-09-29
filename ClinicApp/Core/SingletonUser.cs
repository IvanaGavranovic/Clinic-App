using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Core
{
    public enum UserKind
    {
        PATIENT,
        GENERAL_PRACTICIONER,
        DOCTOR_SPECIALIST
    }
    public class SingletonUser
    {
        private static SingletonUser instance;
        private int userId;
        private UserKind userKind;

        public static SingletonUser Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonUser();
                }

                return instance;
            }

            set
            {
                instance = value;
            }
        }

        public int UserId { get => userId; set => userId = value; }
        public UserKind UserKind { get => userKind; set => userKind = value; }
    }
}
