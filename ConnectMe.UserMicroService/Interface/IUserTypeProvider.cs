namespace ConnectMe.UserMicroService.Interface
{
    public interface IUserTypeProvider
    {
        Task<(bool IsSuccess, string ErrorMessage)> AddUserTypeAsync(UserType userType);

        Task<(bool IsSuccess, IEnumerable<Model.UserType> userTypes ,string ErrorMessage)> GetAllUserTypeAsync();


        Task<(bool IsSuccess, Model.UserType userType, string ErrorMessage)> GetUserTypeAsync(int Id);


        Task<(bool IsSuccess, Model.UserType userType, string ErrorMessage)> UpdateUserTypeAsync(int Id,Model.UserType userType);

        Task<(bool IsSuccess,  string ErrorMessage)> DeleteUserTypeAsync(int Id);
    }
}
