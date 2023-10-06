using AutoMapper;

namespace ConnectMe.UserMicroService.Profile
{
    public class UserServiceProfile : AutoMapper.Profile
    {

        public UserServiceProfile()
        {
            CreateMap<Model.UserProfile, Data.UserProfile>();
            CreateMap<Data.UserProfile, Model.UserProfile>();


            CreateMap<Model.UserType, Data.UserType>();
            CreateMap<Data.UserType, Model.UserType>();
        }
    }
}
