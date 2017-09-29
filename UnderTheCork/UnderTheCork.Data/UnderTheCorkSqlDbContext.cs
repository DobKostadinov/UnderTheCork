using Microsoft.AspNet.Identity.EntityFramework;

using UnderTheCork.Data.Models;

namespace UnderTheCork.Data
{
    public class UnderTheCorkSqlDbContext : IdentityDbContext<User>
    {
        public UnderTheCorkSqlDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static UnderTheCorkSqlDbContext Create()
        {
            return new UnderTheCorkSqlDbContext();
        }
    }
}
