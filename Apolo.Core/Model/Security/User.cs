using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apolo.Core.Model.Security
{
    public class User
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Sex { get; set; }

        public DateTime? Birthday { get; set; }

        public string Details { get; set; }

        public byte[] Avatar { get; set; } = null;

        public string Username { get; set; }

        public string Password { get; set; }

        public Guid Salt { get; set; }

        public string Role { get; set; }
    }
}
