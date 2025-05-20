using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using server.Data;
using server.Dtos.WorkExperience;
using server.Interfaces;
using server.Mappers;

namespace server.Controllers
{
    [Route("api/WorkExperience")]
    [ApiController]
    public class WorkExperienceController:ControllerBase
    {
        private readonly IWorkExperienceRepository _weRepo;
        private readonly ICvRepository _cvRepo;
        public WorkExperienceController(IWorkExperienceRepository eduRepo, ICvRepository cvRepo)
        {
            _weRepo = eduRepo;
            _cvRepo = cvRepo;
        }
        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var WorkExp = await _weRepo.GetAllAsync();
            var weModel = WorkExp.Select(we => we.ToWorkExperienceDto());
            return Ok(weModel);
        }
        [Authorize(Roles = "User")]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var weModel = await _weRepo.GetByIdAsync(id);
            if (weModel == null)
            {
                return BadRequest();
            }
            return Ok(weModel.ToWorkExperienceDto());
        }
        [Authorize(Roles = "User")]
        [HttpPost]
        [Route("{cvId}")]
        public async Task<IActionResult> Create([FromRoute] int cvId, RequestWorkExperienceDto weDto)
        {
            if (!await _cvRepo.ExistCv(cvId))
            {
                return BadRequest("wrong CV Id");
            }

            var weModel = weDto.FromRequestToWorkExperience(cvId);
            var createdModel = await _weRepo.CreateAsync(weModel);
            return CreatedAtAction(nameof(GetById), new { id = weModel }, weModel.ToWorkExperienceDto());
        }
        [Authorize(Roles = "User")]
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, RequestWorkExperienceDto edDto)
        {
            var weModel = await _weRepo.UpdateAsync(id, edDto);
            if (weModel == null)
            {
                return BadRequest("Work Not Found");
            }
            return Ok(weModel);
        }
        [Authorize(Roles = "User")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var weModel = await _weRepo.DeleteAsync(id);
            if (weModel == null)
            {
                return BadRequest("Education Not Found");
            }
            return Ok(weModel);
        }
    }
}
