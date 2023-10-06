using AutoMapper;
using ConnectMe.UserMicroService.Data;
using ConnectMe.UserMicroService.Data.DataAccess;
using ConnectMe.UserMicroService.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Cryptography.Xml;

namespace ConnectMe.UserMicroService.Provider
{
    public class UserProfileProvider : IUserProfileProvider
    {

        private readonly ILogger<UserProfileProvider> logger;
        private readonly IUserProfileDataEF userProfileEF;

        public UserProfileProvider(IUserProfileDataEF userProfileEF, ILogger<UserProfileProvider> logger ) 
        {
            this.userProfileEF = userProfileEF;
            this.logger= logger;
         
        }

        // Add new User
        public async Task<(bool Issuccess, Model.UserProfile? userProfile, string ErrorMessage)> AddUserProfileAsync(Model.UserProfile profile)
        {
            try
            {
                if (profile == null)
                {
                    return (false, null, "User Profile cann't save");
                }
     

                    var newHero = await userProfileEF.AddUserProfileAsync(profile).ConfigureAwait(false);

                    return (true, newHero, "");


                
            }
            catch (Exception ex)
            {

                return (false, null, ex.Message);
            }



        }

        public async Task<(bool Issuccess,  string ErrorMessage)> DeleteUserProfileAsync(int Id)
        {
            try
            {
                var IsDeleted = await userProfileEF.DeleteUserProfileAsync(Id);
        
                 return (IsDeleted,"");
           
            }
            catch (Exception ex)
            {
                return (false,  ex.Message);
            }

        }

        // Get User Profile
        public async Task<(bool IsSuccess, IEnumerable<Model.UserProfile>? userProfiles, string ErrorMessage)> GetAllUserProfileAsync()
        {
            try
            {
                var result = await userProfileEF.GetAllUserProfileAsync().ConfigureAwait(false);
                return (true, result, "");
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message);
            }
          
         
           
        }

        public async Task<(bool Issuccess, Model.UserProfile? userProfile, string ErrorMessage)> GetUserProfileAsync(int Id)
        {
            try
            {
                var userPro = await userProfileEF.GetUserProfileAsync(Id);
         
                    return (true, userPro, "");
                
                ////return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message);
            }
   
        }

        public async Task<(bool Issuccess, Model.UserProfile? userProfile, string ErrorMessage)> UpdateUserProfileAsync(int Id, Model.UserProfile profile)
        {
            try
            {
                var userP = await userProfileEF.UpdateUserProfileAsync(Id, profile).ConfigureAwait(false);



                    return (true, userP, "");
                
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message);
            }

         }
    }
}
