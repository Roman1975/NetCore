using Microsoft.AspNetCore.Identity;

namespace netcore.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class MyUser : IdentityUser<int>, IMyUserCustomization
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int OrganizationId { get; set; }
    }


    public class MyRole : IdentityRole<int>
    {
        public string Description { get; set; }
    }


    public interface IMyUserCustomization
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string MiddleName { get; set; }
        int OrganizationId { get; set; }
    }

}