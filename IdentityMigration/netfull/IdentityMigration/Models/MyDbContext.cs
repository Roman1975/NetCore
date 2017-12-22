using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityMigration.Models
{


    public class MyDbContext
           : IdentityDbContext<MyUser, MyRole, int,
           MyUserLogin, MyUserRole, MyUserClaim>
    {
        public MyDbContext()
            : base("DefaultConnection")
        {
        }

        public static MyDbContext Create()
        {
            return new MyDbContext();
        }
    }

}