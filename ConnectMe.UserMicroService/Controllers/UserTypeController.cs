using ConnectMe.UserMicroService.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ConnectMe.UserMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        private readonly IUserTypeProvider _userType;

        public UserTypeController(IUserTypeProvider userType)
        {
            this._userType = userType;
        }

        [HttpGet("Name=GetAllUserType")]
        public async Task<ActionResult<IEnumerable<Model.UserType>>> GetAllUserType()
        {
            var result = await _userType.GetAllUserTypeAsync();
            if (result.IsSuccess)
            {
                return Ok(result.userTypes);
            }
            return NotFound();
        }


        [HttpPost]
        public async Task<ActionResult> AddUserTypeAsync(UserType userType)
        {
            var result = await _userType.AddUserTypeAsync(userType);
            if (result.IsSuccess)
            {
                return Ok();
            }
            return BadRequest("Could not save");
        }
      
        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateUserType(int Id,UserType userType)
        {
            var result = await _userType.UpdateUserTypeAsync(Id, userType);
            if (result.IsSuccess)
            {
                return Ok(result.userType);
            }
            return NotFound(result.ErrorMessage);
        }
    
      [HttpGet("{Id}")]
      public async Task<IActionResult> GetUserType(int Id)
      {
          var result = await _userType.GetUserTypeAsync(Id);
          if (result.IsSuccess)
          {
              return Ok(result.userType);
          }
          return NotFound(result.ErrorMessage);
      }
     
      [HttpDelete("{Id}")]
      public async Task<IActionResult> DeleteUserType(int Id)
      {
          var result = await _userType.DeleteUserTypeAsync(Id);
          if (result.IsSuccess)
          {
              return Ok();
          }
          return NotFound(result.ErrorMessage);
      }
  

    }
}
