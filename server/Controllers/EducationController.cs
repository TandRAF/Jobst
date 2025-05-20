using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using server.Data;
using server.Dtos.Education;
using server.Interfaces;
using server.Mappers;

namespace server.Controllers
{
    [Route("api/Education")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IEducationRepository _eduRepo;
        private readonly ICvRepository _cvRepo;
        public EducationController(IEducationRepository eduRepo, ICvRepository cvRepo)
        {
            _eduRepo = eduRepo;
            _cvRepo = cvRepo;
        }
        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Edu = await _eduRepo.GetAllAsync();
            var EduModels = Edu.Select(edu => edu.ToEducationDto());
            return Ok(EduModels);
        }
        [Authorize(Roles = "User")]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var EduModel = await _eduRepo.GetByIDAsync(id);
            if (EduModel == null)
            {
                return BadRequest();
            }
            return Ok(EduModel.ToEducationDto());
        }
        [Authorize(Roles = "User")]
        [HttpPost]
        [Route("{cvId}")]
        public async Task<IActionResult> Create([FromRoute] int cvId, RequestEducationDto edDto)
        {
            if (!await _cvRepo.ExistCv(cvId))
            {
                return BadRequest("wrong CV Id");
            }

            var EduModel = edDto.ToEduFromRequest(cvId);
            var createdModel = await _eduRepo.CreateAsync(EduModel);
            return CreatedAtAction(nameof(GetById), new { id = EduModel }, EduModel.ToEducationDto());
        }
        [Authorize(Roles = "User")]
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, RequestEducationDto edDto)
        {
            var edModel = await _eduRepo.UpdateAsync(id, edDto);
            if (edModel == null)
            {
                return BadRequest("Education Not Found");
            }
            return Ok(edModel);
        }
        [Authorize(Roles = "User")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var edModel = await _eduRepo.DeleteAsync(id);
            if (edModel == null)
            {
                return BadRequest("Education Not Found");
            }
            return Ok(edModel);
        }
    }
}
