using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using server.Interfaces;
using server.Mappers;
using server.Dtos.JobOffer;
using server.Model;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobOfferController : ControllerBase
    {
        private readonly IJobOfferRepository _repo;
        private readonly ICompanyProfileRepository _companyProfileRepo;
        private readonly UserManager<UserBase> _userManager;

        public JobOfferController(
            IJobOfferRepository repo,
            ICompanyProfileRepository companyProfileRepo,
            UserManager<UserBase> userManager)
        {
            _repo = repo;
            _companyProfileRepo = companyProfileRepo;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var jobOffers = await _repo.GetAllAsync();
            return Ok(jobOffers.Select(JobOfferMapper.ToResponseDTO));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var jobOffer = await _repo.GetByIdAsync(id);
            if (jobOffer == null) return NotFound();
            return Ok(JobOfferMapper.ToResponseDTO(jobOffer));
        }

        [HttpPost]
        public async Task<IActionResult> Create(RequestJobOfferDTO dto)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var jobOffer = await _companyProfileRepo.CreateJobOfferAsync(user.Id, dto);
            if (jobOffer == null) return BadRequest();
            return Ok(JobOfferMapper.ToResponseDTO(jobOffer));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RequestJobOfferDTO dto)
        {
            var jobOffer = await _repo.UpdateAsync(id, dto);
            if (jobOffer == null) return NotFound();
            return Ok(JobOfferMapper.ToResponseDTO(jobOffer));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var jobOffer = await _repo.DeleteAsync(id);
            if (jobOffer == null) return NotFound();
            return Ok(JobOfferMapper.ToResponseDTO(jobOffer));
        }
    }
}