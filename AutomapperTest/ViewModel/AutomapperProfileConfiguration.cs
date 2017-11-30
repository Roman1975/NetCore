using AutoMapper;
using AutomapperTest.Model;

namespace AutomapperTest.ViewModel
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        : this("MyProfile")
        {
        }
        protected AutoMapperProfileConfiguration(string profileName)
        : base(profileName)
        {
            CreateMap<UserViewModel, User>();
            CreateMap<User, UserViewModel>();
        }
    }
}