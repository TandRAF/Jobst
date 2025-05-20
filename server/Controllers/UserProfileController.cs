using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.Dtos.CV;
using server.Interfaces;
using server.Mappers;
using server.Model;
namespace server.Controllers
{
    [Route("api/UserProfile")]
    [ApiController]
    public class UserProfileController:ControllerBase
    {   
        private readonly IUserProfileRepository _upRepo;
        private readonly UserManager<UserBase> _user;
        public UserProfileController(IUserProfileRepository upRepo, UserManager<UserBase> user){
            _upRepo = upRepo;
            _user = user;
        }
        [Authorize]
        [HttpGet("Get-my-profile")]
        public async Task<IActionResult> GetById(){
            var userModel = await _user.GetUserAsync(User);
            var Up = await _upRepo.GetByIdAsync(userModel.Id);
            var upModel = Up.ToUserProfileDto();
            if(upModel == null){
                return BadRequest("Not Exist");
            }
            return Ok(upModel);
        }
    }
}
