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
            context.Users.Add(GetPatientUser());
            context.SaveChanges();
        }

        private User GetAdminUser()
        {
            Guid guid = new Guid();
            byte[] avatar = System.IO.File.ReadAllBytes(@"D:\Documents\Visual Studio 2017\Projects\Apolo\Apolo.Web\Assets\temp\jsandoval.png");
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
            byte[] avatar = System.IO.File.ReadAllBytes(@"D:\Documents\Visual Studio 2017\Projects\Apolo\Apolo.Web\Assets\temp\fcaceres.png");
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

        private User GetPatientUser()
        {
            Guid guid = new Guid();
            byte[] avatar = System.IO.File.ReadAllBytes(@"D:\Documents\Visual Studio 2017\Projects\Apolo\Apolo.Web\Assets\temp\sccahua.png");
            User user = new User
            {
                FirstName = "Sheila",
                LastName = "Ccahua",
                Birthday = new DateTime(1992, 09, 14),
                Username = "sccahua",
                Password = SecurityUtil.GenerateSaltedHash("sccahua", guid.ToString()),
                Salt = guid,
                Role = Constants.Roles.PATIENT,
                Avatar = avatar
            };
            return user;
        }
    }
}
