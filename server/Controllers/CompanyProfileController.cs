using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.Dtos.JobOffer;
using server.Interfaces;
using server.Mappers;
using server.Model;

namespace server.Controllers
{
    [Route("api/CompanyProfile")]
    [ApiController]
    public class CompanyProfileController : ControllerBase
    {
        private readonly ICompanyProfileRepository _cpRepo;
        private readonly UserManager<UserBase> _userManager;
        private readonly ApplicationDBContext _context;

        public CompanyProfileController(ICompanyProfileRepository cpRepo, UserManager<UserBase> userManager, ApplicationDBContext context)
        {
            _cpRepo = cpRepo;
            _userManager = userManager;
            _context = context;
        }

        [Authorize]
        [HttpGet("Get-my-profile")]
        public async Task<IActionResult> GetMyProfile()
        {
            var userModel = await _userManager.GetUserAsync(User);
            if (userModel == null)
                return Unauthorized();

            var companyProfile = await _cpRepo.GetByIdAsync(userModel.Id);
            if (companyProfile == null)
                return NotFound("Profile does not exist.");

            var dto = companyProfile.ToCompanyProfileDto();
            return Ok(dto);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RequestJobOfferDTO dto)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var jobOffer = await _cpRepo.CreateJobOfferAsync(user.Id, dto);
            if (jobOffer == null) return BadRequest("No company profile found for this user.");

            return Ok(JobOfferMapper.ToResponseDTO(jobOffer));
        }
    }
}
