using Apolo.Core.Model;
using Apolo.Core.Model.Security;
using Apolo.Core.Util;
using System;
using System.Collections.Generic;

namespace Apolo.Core.Data
{
    public class ApoloInitializer : System.Data.Entity.DropCreateDatabaseAlways<ApoloContext>
    {
        protected override void Seed(ApoloContext context)
        {
            context.Users.Add(GetAdminUser());
            context.Users.Add(GetTherapistUser());
            foreach(var patient in GetPatientUsers())
            {
                context.Users.Add(patient);
            }
            context.SaveChanges();
        }

        private User GetAdminUser()
        {
            Guid guid = new Guid();
            byte[] avatar = System.IO.File.ReadAllBytes(@".\temp\jsandoval.png");
            User user = new User
            {
                FirstName = "José",
                LastName = "Sandoval",
                Birthday = new DateTime(1993, 6, 20),
                Username = "jsandoval",
                Password = SecurityUtil.GenerateSaltedHash("jsandoval", guid.ToString()),
                Salt = guid,
                Role = Constants.Roles.ADMINISTRATOR,
                Avatar = avatar
            };
            return user;
        }

        private User GetTherapistUser()
        {
            Guid guid = new Guid();
            byte[] avatar = System.IO.File.ReadAllBytes(@".\temp\fcaceres.png");
            User user = new User
            {
                FirstName = "Franco",
                LastName = "Cáceres",
                Birthday = new DateTime(1994, 10, 24),
                Username = "fcaceres",
                Password = SecurityUtil.GenerateSaltedHash("fcaceres", guid.ToString()),
                Salt = guid,
                Role = Constants.Roles.THERAPIST,
                Avatar = avatar
            };
            return user;
        }

        private List<User> GetPatientUsers()
        {
            List<User> patients = new List<User>();

            #region Sheila
            Guid guid = new Guid();
            byte[] avatar = System.IO.File.ReadAllBytes(@".\temp\sccahua.png");
            User user = new User
            {
                FirstName = "Sheila",
                LastName = "Ccahua",
                Birthday = new DateTime(1992, 09, 14),
                Username = "sccahua",
                Password = SecurityUtil.GenerateSaltedHash("sccahua", guid.ToString()),
                Salt = guid,
                Role = Constants.Roles.PATIENT,
                Avatar = avatar,
                Gender = Constants.Genders.FEMALE,
                Condition = Constants.Conditions.HEMORRAGHIC
            };
            patients.Add(user);
            #endregion

            #region Tanya
            guid = new Guid();
            avatar = System.IO.File.ReadAllBytes(@".\temp\tluna.png");
            user = new User
            {
                FirstName = "Tanya",
                LastName = "Luna",
                Birthday = new DateTime(1995, 1, 14),
                Username = "tluna",
                Password = SecurityUtil.GenerateSaltedHash("tluna", guid.ToString()),
                Salt = guid,
                Role = Constants.Roles.PATIENT,
                Avatar = avatar,
                Gender = Constants.Genders.FEMALE,
                Condition = Constants.Conditions.ISCHEMIC
            };
            patients.Add(user);
            #endregion

            #region Marcos
            guid = new Guid();
            avatar = System.IO.File.ReadAllBytes(@".\temp\mdiaz.png");
            user = new User
            {
                FirstName = "Marcos",
                LastName = "Diaz",
                Birthday = new DateTime(1955, 5, 20),
                Username = "mdiaz",
                Password = SecurityUtil.GenerateSaltedHash("mdiaz", guid.ToString()),
                Salt = guid,
                Role = Constants.Roles.PATIENT,
                Avatar = avatar,
                Gender = Constants.Genders.MALE,
                Condition = Constants.Conditions.HEMORRAGHIC
            };
            patients.Add(user);
            #endregion

            #region Andrea
            guid = new Guid();
            avatar = System.IO.File.ReadAllBytes(@".\temp\apereira.png");
            user = new User
            {
                FirstName = "Andrea",
                LastName = "Pereira",
                Birthday = new DateTime(1995, 2, 11),
                Username = "apereira",
                Password = SecurityUtil.GenerateSaltedHash("apereira", guid.ToString()),
                Salt = guid,
                Role = Constants.Roles.PATIENT,
                Avatar = avatar,
                Gender = Constants.Genders.FEMALE,
                Condition = Constants.Conditions.ISCHEMIC
            };
            patients.Add(user);
            #endregion

            #region Carlos
            guid = new Guid();
            avatar = System.IO.File.ReadAllBytes(@".\temp\cmendoza.png");
            user = new User
            {
                FirstName = "Carlos",
                LastName = "Mendoza",
                Birthday = new DateTime(1991, 4, 12),
                Username = "cmendoza",
                Password = SecurityUtil.GenerateSaltedHash("cmendoza", guid.ToString()),
                Salt = guid,
                Role = Constants.Roles.PATIENT,
                Avatar = avatar,
                Gender = Constants.Genders.MALE,
                Condition = Constants.Conditions.HEMORRAGHIC
            };
            patients.Add(user);
            #endregion

            #region Diana
            guid = new Guid();
            avatar = System.IO.File.ReadAllBytes(@".\temp\dcriollo.png");
            user = new User
            {
                FirstName = "Diana",
                LastName = "Criollo",
                Birthday = new DateTime(1965, 5, 28),
                Username = "dcriollo",
                Password = SecurityUtil.GenerateSaltedHash("dcriollo", guid.ToString()),
                Salt = guid,
                Role = Constants.Roles.PATIENT,
                Avatar = avatar,
                Gender = Constants.Genders.FEMALE,
                Condition = Constants.Conditions.ISCHEMIC
            };
            patients.Add(user);
            #endregion

            #region Claudio
            guid = new Guid();
            avatar = System.IO.File.ReadAllBytes(@".\temp\chulerig.png");
            user = new User
            {
                FirstName = "Claudio",
                LastName = "Hulerig",
                Birthday = new DateTime(1980, 4, 12),
                Username = "chulerig",
                Password = SecurityUtil.GenerateSaltedHash("chulerig", guid.ToString()),
                Salt = guid,
                Role = Constants.Roles.PATIENT,
                Avatar = avatar,
                Gender = Constants.Genders.MALE,
                Condition = Constants.Conditions.HEMORRAGHIC
            };
            patients.Add(user);
            #endregion

            #region Luis Renato
            guid = new Guid();
            avatar = System.IO.File.ReadAllBytes(@".\temp\lrodriguez.png");
            user = new User
            {
                FirstName = "Luis Renato",
                LastName = "Rodriguez",
                Birthday = new DateTime(1990, 7, 9),
                Username = "lrodriguez",
                Password = SecurityUtil.GenerateSaltedHash("lrodriguez", guid.ToString()),
                Salt = guid,
                Role = Constants.Roles.PATIENT,
                Avatar = avatar,
                Gender = Constants.Genders.MALE,
                Condition = Constants.Conditions.ISCHEMIC
            };
            patients.Add(user);
            #endregion

            #region Cynthia
            guid = new Guid();
            avatar = System.IO.File.ReadAllBytes(@".\temp\csanchez.png");
            user = new User
            {
                FirstName = "Cynthia",
                LastName = "Sanchez",
                Birthday = new DateTime(1985, 1, 18),
                Username = "csanchez",
                Password = SecurityUtil.GenerateSaltedHash("csanchez", guid.ToString()),
                Salt = guid,
                Role = Constants.Roles.PATIENT,
                Avatar = avatar,
                Gender = Constants.Genders.FEMALE,
                Condition = Constants.Conditions.HEMORRAGHIC
            };
            patients.Add(user);
            #endregion

            #region Milagros
            guid = new Guid();
            avatar = System.IO.File.ReadAllBytes(@".\temp\mrojas.png");
            user = new User
            {
                FirstName = "Milagros",
                LastName = "Rojas",
                Birthday = new DateTime(1970, 11, 5),
                Username = "mrojas",
                Password = SecurityUtil.GenerateSaltedHash("mrojas", guid.ToString()),
                Salt = guid,
                Role = Constants.Roles.PATIENT,
                Avatar = avatar,
                Gender = Constants.Genders.FEMALE,
                Condition = Constants.Conditions.ISCHEMIC
            };
            patients.Add(user);
            #endregion

            #region Andres
            guid = new Guid();
            avatar = System.IO.File.ReadAllBytes(@".\temp\aherrera.png");
            user = new User
            {
                FirstName = "Andres",
                LastName = "Herrera",
                Birthday = new DateTime(1960, 3, 15),
                Username = "aherrera",
                Password = SecurityUtil.GenerateSaltedHash("aherrera", guid.ToString()),
                Salt = guid,
                Role = Constants.Roles.PATIENT,
                Avatar = avatar,
                Gender = Constants.Genders.MALE
            };
            patients.Add(user);
            #endregion

            return patients;
        }
    }
}
