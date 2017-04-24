using Apolo.Core.Model.Security;
using System.Data.Entity;

namespace Apolo.Core.Data
{
    public class ApoloContext : DbContext
    {
        public ApoloContext() : base("ApoloContext")
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
