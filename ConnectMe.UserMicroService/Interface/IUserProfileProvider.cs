using ConnectMe.UserMicroService.Model;

namespace ConnectMe.UserMicroService.Interface
{
    public interface IUserProfileProvider
    {
        Task<(bool IsSuccess, IEnumerable<UserProfile>? userProfiles, string ErrorMessage)> GetAllUserProfileAsync();

        Task<(bool Issuccess, UserProfile? userProfile, string ErrorMessage)> AddUserProfileAsync(UserProfile profile);

        Task<(bool Issuccess, UserProfile? userProfile, string ErrorMessage)> GetUserProfileAsync(int Id);

        Task<(bool Issuccess, UserProfile? userProfile, string ErrorMessage)> UpdateUserProfileAsync(int Id, UserProfile profile);

        Task<(bool Issuccess, string ErrorMessage)> DeleteUserProfileAsync(int Id);

    }
}
