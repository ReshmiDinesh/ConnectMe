namespace ConnectMe.UserMicroService.Data.DataAccess
{
    public interface IUserProfileDataEF
    {
        Task<IEnumerable<Model.UserProfile>?> GetAllUserProfileAsync();

        Task<Model.UserProfile?> AddUserProfileAsync(Model.UserProfile profile);

        Task<Model.UserProfile?> GetUserProfileAsync(int Id);

        Task<Model.UserProfile?> UpdateUserProfileAsync(int Id, Model.UserProfile profile);

        Task<bool> DeleteUserProfileAsync(int Id);

    }
}
