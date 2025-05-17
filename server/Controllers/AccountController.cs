using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Dtos.Account;
using server.Interfaces;
using server.Model;

namespace server.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController:ControllerBase
    {
        private readonly UserManager<UserBase> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<UserBase> _signinManager;
        private readonly ApplicationDBContext _context;
        public AccountController(UserManager<UserBase> userManager,ITokenService tokenService,SignInManager<UserBase> signinManager,ApplicationDBContext context){
            _userManager = userManager;
            _tokenService = tokenService;
            _signinManager = signinManager;
            _context = context;
        }
        [HttpPut("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto logindto){
            if(!ModelState.IsValid){
                return BadRequest();
            }
            var user = await _userManager.Users.FirstOrDefaultAsync(u=>u.UserName == logindto.UserName);
            if(user == null) return Unauthorized("Invalid User Name");
            var result = await _signinManager.CheckPasswordSignInAsync(user,logindto.Password,false);
            if(!result.Succeeded) return Unauthorized("User Not Found Or password is invalid"); 
            return Ok(new NewUserDto{
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Token = await _tokenService.CreateToken(user)
            });
        }
        [HttpPost("register")]
public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
{
    try
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // Create a new UserBase (IdentityUser)
        var appUser = new UserBase
        {
            UserName = registerDto.UserName,
            Email = registerDto.Email,
        };

        // Create the user with the password provided
        var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

        if (createdUser.Succeeded)
        {
            // Assign role based on the input from the registration form
            var role = registerDto.Role; // Role can be "User" or "Company"

            // Check if the role is valid
            if (role != "User" && role != "Company")
            {
                return BadRequest("Invalid role selected.");
            }

            var roleResult = await _userManager.AddToRoleAsync(appUser, role);

            if (roleResult.Succeeded)
            {
                // Optionally, create user profile based on role
                if (role == "User")
                {
                    // Create UserProfile (you can modify this part to suit your needs)
                    _context.UserProfile.Add(new UserProfile { UserId = appUser.Id });
                }
                else if (role == "Company")
                {
                    // Create CompanyProfile (you can modify this part to suit your needs)
                    _context.CompanyProfile.Add(new CompanyProfile { UserId = appUser.Id });
                }

                await _context.SaveChangesAsync();
                return Ok(
                    new NewUserDto
                    {
                        UserName = appUser.UserName,
                        Email = appUser.Email,
                        Token = await _tokenService.CreateToken(appUser),
                    }
                );
            }
            else
            {
                return StatusCode(500, roleResult.Errors);
            }
        }
        else
        {
            return StatusCode(500, createdUser.Errors);
        }
    }
    catch (SqlException sqlEx)
    {
        var errorResponse = new
        {
            message = "A database error occurred.",
            error = sqlEx.Message,      // SQL exception message
            stackTrace = sqlEx.StackTrace // Stack trace for debugging purposes
        };
        
        return StatusCode(500, errorResponse);
    }
    catch (Exception ex)
    {
        // General exception handling (fallback)
        var errorResponse = new
        {
            message = "An error occurred while processing your request.",
            error = ex.Message,
            stackTrace = ex.StackTrace
        };
        
        return StatusCode(500, errorResponse);
    }
}

    }
}
