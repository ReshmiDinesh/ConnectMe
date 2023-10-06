using AutoMapper;
using ConnectMe.UserMicroService.Data;
using ConnectMe.UserMicroService.Interface;
using ConnectMe.UserMicroService.Model;

namespace ConnectMe.UserMicroService.Provider
{
    public class UserTypeProvider : IUserTypeProvider
    {
        private readonly ConnectMeContext _connectMeContext;
        private readonly ILogger<UserProfileProvider> logger;
        private readonly IMapper mapper;

        public UserTypeProvider(ConnectMeContext connectMeContext, ILogger<UserProfileProvider> logger, IMapper mapper) 
        { 
            this._connectMeContext = connectMeContext;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<(bool IsSuccess, string ErrorMessage)> AddUserTypeAsync(Model.UserType userType)
        {
            if (userType == null)
            {
                return (false, "UserType can't save");
            }
            try
            {
                var newType =this.mapper.Map<Model.UserType, Data.UserType>(userType);

                _connectMeContext.UserTypes.Add(newType);
                await _connectMeContext.SaveChangesAsync();
                return (true, "");
            }
            catch (Exception ex)
            {

                return (false, ex.Message.ToString());
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Model.UserType>? userTypes, string ErrorMessage)> GetAllUserTypeAsync()
        {
            try
            {
                var userType = await _connectMeContext.UserTypes.ToListAsync();

               if (userType != null)
                {
                    return (true, mapper.Map<IEnumerable<Data.UserType>, IEnumerable<Model.UserType> >(userType), "");
                }
                return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message.ToString());
            }
        
        }

        public async Task<(bool IsSuccess, Model.UserType? userType, string ErrorMessage)> GetUserTypeAsync(int Id)
        {
            try
            {
                var userType = await _connectMeContext.UserTypes.FirstOrDefaultAsync(x => x.UserTypeId == Id);

                if (userType != null)
                {
                    return (true, mapper.Map<Data.UserType, Model.UserType>(userType), "");
                }
                return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message.ToString());
            }
        }

        public async Task<(bool IsSuccess, Model.UserType? userType, string ErrorMessage)> UpdateUserTypeAsync(int Id,Model.UserType userType)
        {
            try
            {
                var uT = await _connectMeContext.UserTypes.FirstOrDefaultAsync(x => x.UserTypeId == Id);

                if (uT != null)
                {
                    uT.UserType1 = userType.UserType1;
                    await _connectMeContext.SaveChangesAsync();

                    return (true, mapper.Map<Data.UserType, Model.UserType>(uT), "");
                }
                return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message.ToString());
            }
        }

        public async Task<(bool IsSuccess, string ErrorMessage)> DeleteUserTypeAsync(int Id)
        {
            try
            {
                var uT = await _connectMeContext.UserTypes.FirstOrDefaultAsync(x => x.UserTypeId == Id);

                if (uT != null)
                {
                         _connectMeContext.UserTypes.Remove(uT);
                    await _connectMeContext.SaveChangesAsync();

                    return (true,  "");
                }
                return (false,  "Not Found");
            }
            catch (Exception ex)
            {
                return (false,  ex.Message.ToString());
            }
        }
    }
}
