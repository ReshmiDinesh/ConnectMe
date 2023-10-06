using AutoMapper;
using ConnectMe.UserMicroService.Provider;

namespace ConnectMe.UserMicroService.Data.DataAccess
{
    public class UserProfileEF : IUserProfileDataEF
    {
        private readonly ConnectMeContext _connectMeContext;
        private readonly IMapper mapper;

        public UserProfileEF(ConnectMeContext connectMeContext, IMapper mapper)
        {
            _connectMeContext = connectMeContext;
            this.mapper = mapper;
        }

        public async Task<Model.UserProfile?> AddUserProfileAsync(Model.UserProfile profile)
        {
            var userProfile = mapper.Map<Model.UserProfile, Data.UserProfile>(profile);
            _connectMeContext.UserProfiles.Add(userProfile);
            await _connectMeContext.SaveChangesAsync();

            var newHero = await _connectMeContext.UserProfiles.FirstOrDefaultAsync(x => x.UserName == profile.UserName);

            return mapper.Map<Data.UserProfile, Model.UserProfile>(newHero);
        }

        public async Task<bool> DeleteUserProfileAsync(int Id)
        {
            var userPro = await _connectMeContext.UserProfiles.FirstOrDefaultAsync(x => x.UserProfileId == Id);
            if (userPro != null)
            {
                _connectMeContext.UserProfiles.Remove(userPro);
                await _connectMeContext.SaveChangesAsync();

                return (true);

            }
           
            return false;
        }

        public async Task<IEnumerable<Model.UserProfile>?> GetAllUserProfileAsync()
        {
            var result = await _connectMeContext.UserProfiles.ToListAsync();
            if (result.Any())
            {
                var userProfile = mapper.Map<IEnumerable<Data.UserProfile>, IEnumerable<Model.UserProfile>>(result);
                return userProfile;
            }
          return null;

        }

        public async Task<Model.UserProfile?> GetUserProfileAsync(int Id)
        {
            var userPro = await _connectMeContext.UserProfiles.FirstOrDefaultAsync(x => x.UserProfileId == Id);
            if (userPro != null)
            {
                return ( mapper.Map<Data.UserProfile, Model.UserProfile>(userPro));
            }
          

            return null;
        }

        public async Task<Model.UserProfile?> UpdateUserProfileAsync(int Id, Model.UserProfile profile)
        {
            var userP = await _connectMeContext.UserProfiles.FirstOrDefaultAsync(x => x.UserProfileId == Id);
            if (userP != null)
            {
                userP.FirstName = profile.FirstName;
                userP.LastName = profile.LastName;
                userP.Email = profile.Email;
                userP.DateOfBirth = profile.DateOfBirth;
                userP.Gender = profile.Gender;
                userP.IsActive = profile.IsActive;
                userP.MiddleName = profile.MiddleName;
                //userP.UserType = profile.UserTypeId

                await _connectMeContext.SaveChangesAsync();

                return (mapper.Map<Data.UserProfile, Model.UserProfile>(userP));
            }
            return null;
        }
    }
}
