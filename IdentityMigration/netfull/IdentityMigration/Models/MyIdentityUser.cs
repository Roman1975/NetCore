using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityMigration.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class MyUser : IdentityUser<int, MyUserLogin, MyUserRole, MyUserClaim>, IUser<int>, IMyUserCustomization
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<MyUser, int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        [Index]
        public int OrganizationId { get; set; }
    }

    public class MyUserLogin : IdentityUserLogin<int> { }
    
    public class MyUserRole : IdentityUserRole<int> { }

    public class MyUserClaim : IdentityUserClaim<int> { }

    public class ApplicationUserStore :
        UserStore<MyUser, MyRole, int,
        MyUserLogin, MyUserRole, MyUserClaim>, IUserStore<MyUser, int>
    {
        public ApplicationUserStore()
            : this(new IdentityDbContext())
        {
            base.DisposeContext = true;
        }

        public ApplicationUserStore(DbContext context)
            : base(context)
        {
        }
    }

    public class MyRole : IdentityRole<int, MyUserRole>, IRole<int>
    {
        public MyRole() : base() { }
        public MyRole(string name)
            : this()
        {
            this.Name = name;
        }
    }

    public interface IMyUserCustomization
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string MiddleName { get; set; }
        int OrganizationId { get; set; }
    }
}