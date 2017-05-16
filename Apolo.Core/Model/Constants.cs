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
        public const string SESSION_PATIENT = "SESSION_PATIENT";
        public const string SESSION_ROUTINEBLUEPRINT = "SESSION_ROUTINEBLUEPRINT";

        public static class Roles
        {
            public const string ADMINISTRATOR = "Administrador";
            public const string THERAPIST = "Terapeuta";
            public const string PATIENT = "Paciente";
        }

        public static class Operation
        {
            public const string BLUEPRINT_ID = "BLUEPRINT_ID";
            public const string START_DATE = "START_DATE";
            public const string THERAPIST_ID = "THERAPIST_ID";
            public const string PATIENT_ID = "PATIENT_ID";
            public const string GOAL = "GOAL";
            public const string DETAILS = "DETAILS";
        }

        public static class Areas
        {
            public const string ADMINISTRATOR = "Administrator";
            public const string THERAPIST = "Therapist";
            public const string PATIENT = "Patient";
        }

        public static class Genders
        {
            public const string MALE = "Masculino";
            public const string FEMALE = "Femenino";
        }

        public static class Conditions
        {
            public const string ISCHEMIC = "Infarto Cerebral";
            public const string HEMORRAGHIC = "Derrame Cerebral";
        }

        public static class Games
        {
            public const string PONG = "Pong";
            public const string TETRIS = "Tetris";
            public const string INVADERS = "Invasores";

            public static class Difficulty
            {
                public const string EASY = "Fácil";
                public const string MEDIUM = "Medio";
                public const string HARD = "Difícil";
            }
        }

        public static class Routines
        {
            public static class Categories
            {
                public const string BASIC = "Básico";
                public const string INTERMEDIATE = "Intermedio";
                public const string ADVANCED = "Avanzado";
            }
        }
    }
}
