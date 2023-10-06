using ConnectMe.UserMicroService.Data;
using ConnectMe.UserMicroService.Interface;
using ConnectMe.UserMicroService.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConnectMe.UserMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileProvider userProfileProvider;

        public UserProfileController(IUserProfileProvider userProfileProvider)
        {
            this.userProfileProvider = userProfileProvider;

        }

        [HttpGet]
        public async Task<IActionResult> GetUserProfileAsync()
        {
            var result = await userProfileProvider.GetAllUserProfileAsync();
            if(result.IsSuccess)
            {
                return Ok(result.userProfiles);
            }  
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddUserProfileAsync(Model.UserProfile userProfile)
        {
            var result = await userProfileProvider.AddUserProfileAsync(userProfile);
            if (result.Issuccess)
            {
                return Ok(result.userProfile);
            }
            return BadRequest(result.ErrorMessage);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetUserProfileAsync(int Id)
        {
            var result = await userProfileProvider.GetUserProfileAsync(Id);
            if (result.Issuccess)
            {
                return Ok(result.userProfile);
            }
            return BadRequest(result.ErrorMessage);

        }

        [HttpPut("{Id}")]
        public async Task<IAsyncResult> UpdateUserProfileAsyn(Int Id,Model.UserProfile userProfile)
        {
            var result = await userProfileProvider.UpdateUserProfileAsync(Id, userProfile);
            if (result.Issuccess)
            {
                return Ok(result.userProfile);
            }
            return BadRequest(result.ErrorMessage);
        }
    }
}
