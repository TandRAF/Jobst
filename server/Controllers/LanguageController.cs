using System;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Dtos.Language;
using server.Interfaces;
using server.Mappers;

namespace server.Controllers
{
    public class LanguageController:ControllerBase
    {
        
        private readonly ILanguageRepository _lnRepo;
        private readonly ICvRepository _cvRepo;
        public LanguageController(ILanguageRepository lnRepo, ICvRepository cvRepo)
        {
            _lnRepo = lnRepo;
            _cvRepo = cvRepo;
        }
        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ln = await _lnRepo.GetAllAsync();
            var lnModel = ln.Select(we => we.ToLanguageDto());
            return Ok(lnModel);
        }
        [Authorize(Roles = "User")]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var lnModel = await _lnRepo.GetByIdAsync(id);
            if (lnModel == null)
            {
                return BadRequest();
            }
            return Ok(lnModel.ToLanguageDto());
        }
        [Authorize(Roles = "User")]
        [HttpPost]
        [Route("{cvId}")]
        public async Task<IActionResult> Create([FromRoute] int cvId, RequestLanguageDto lnDto)
        {
            if (!await _cvRepo.ExistCv(cvId))
            {
                return BadRequest("wrong CV Id");
            }

            var lnModel = lnDto.FromRequesteToLangauge(cvId);
            var createdModel = await _lnRepo.CreateAsync(lnModel);
            return CreatedAtAction(nameof(GetById), new { id = lnModel }, lnModel.ToLanguageDto());
        }
        [Authorize(Roles = "User")]
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, RequestLanguageDto edDto)
        {
            var lnModel = await _lnRepo.UpdateAsync(id, edDto);
            if (lnModel == null)
            {
                return BadRequest("Work Not Found");
            }
            return Ok(lnModel);
        }
        [Authorize(Roles = "User")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var lnModel = await _lnRepo.DeleteAsync(id);
            if (lnModel == null)
            {
                return BadRequest("Education Not Found");
            }
            return Ok(lnModel.ToLanguageDto());
        }
    }
}
