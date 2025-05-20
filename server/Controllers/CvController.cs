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
    [Route("api/CV")]
    [ApiController]
    public class CvController : ControllerBase
    {
        private readonly ICvRepository _cvRepo;
        private readonly UserManager<UserBase> _user;
        public CvController(ICvRepository cvRepo, UserManager<UserBase> user)
        {
            _cvRepo = cvRepo;
            _user = user;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var CVs = await _cvRepo.GetAllAsync();
            var CvModels = CVs.Select(cv => cv.ToCvDto());
            return Ok(CvModels);
        }
        [Authorize(Roles = "User")]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var userModel = await _user.GetUserAsync(User);
            var CvModel = await _cvRepo.GetByIdAsync(Id);
            if (CvModel == null)
            {
                return BadRequest();
            }
            return Ok(CvModel.ToCvDto());
        }
        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RequestCvDto requestCvDto)
        {
            var cvModel = requestCvDto.ToCvFromRequest();
            var user = await _user.GetUserAsync(User);
            await _cvRepo.CreateAsync(cvModel, user);
            return CreatedAtAction(nameof(GetById), new { id = cvModel.Id }, cvModel.ToCvDto());
        }
        [Authorize(Roles = "User")]
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCvDto updateCvDto)
        {
            var cvModel = await _cvRepo.UpdateAsync(id, updateCvDto);
            if (cvModel == null)
            {
                return BadRequest("CV not Found");
            }
            return Ok(cvModel);
        }
        [Authorize(Roles = "User")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var cvModel = await _cvRepo.DeleteAsync(id);
            if (cvModel == null)
            {
                return BadRequest("Not Found CV");
            }
            return Ok(cvModel);
        }
    }
}
 