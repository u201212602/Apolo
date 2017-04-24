using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apolo.Core.Model
{
    public static class Constants
    {
        public const string SESSION_USER = "SESSION_USER";

        public static class Roles
        {
            public const string ADMINISTRATOR = "Administrador";
            public const string THERAPIST = "Terapeuta";
            public const string PATIENT = "Paciente";
        }

        public static class Areas
        {
            public const string ADMINISTRATOR = "Administrator";
            public const string THERAPIST = "Therapist";
            public const string PATIENT = "Patient";
        }
    }
}
