using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Dictionary;
using LaborVolumeCalculator.DTO;
using AutoMapper;
using LaborVolumeCalculator.Repositories.Contracts;
using LaborVolumeCalculator.Utils;

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OntdLaborController : ControllerBase<OntdLabor, LaborDto>
    {
        private readonly IRepository<OntdLabor> _ontdLabors;

        public OntdLaborController(IRepository<OntdLabor> ontdLabors, IMapper mapper) : base(mapper)
        {
            this._ontdLabors = ontdLabors;
        }

        // GET: api/OntdLabor
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<LaborDto>>> GetOntdLabors()
        {
            var labors = await _ontdLabors.GetAll().ToListAsync();
            var laborsDto = ConvertToDto(labors)
                .OrderBy(m => m.Code, CodeComparer.Instance)
                .ToArray();
            return laborsDto;
        }

        // GET: api/OntdLabor/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LaborDto>> GetOntdLabor(int id)
        {
            var ontdLabor = await _ontdLabors.FirstOrDefaultAsync(m => m.ID == id);

            if (ontdLabor == null)
            {
                return NotFound();
            }

            return ConvertToDto(ontdLabor);
        }

        // PUT: api/OntdLabor/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // validation errors
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<LaborDto>> PutOntdLabor(int id, LaborDto ontdLaborDto)
        {
            if (id != ontdLaborDto.ID)
            {
                return BadRequest();
            }
            var ontdLabor = ConvertToSource(ontdLaborDto);

            _ontdLabors.Update(ontdLabor);

            try
            {
                await _ontdLabors.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OntdLaborExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return Conflict();
                }
            }

            ontdLabor = await _ontdLabors.FirstOrDefaultAsync(m => m.ID == ontdLabor.ID);
            return Ok(ConvertToDto(ontdLabor));
        }

        // POST: api/OntdLabor
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // validation errors
        public async Task<ActionResult<LaborDto>> PostOntdLabor(LaborCreateDto ontdLaborDto)
        {
            var ontdLabor = ConvertToSource(ontdLaborDto);
            
            _ontdLabors.Add(ontdLabor);
            await _ontdLabors.SaveChangesAsync();

            ontdLabor = await _ontdLabors.FirstOrDefaultAsync(m => m.ID == ontdLabor.ID);
            return CreatedAtAction("GetOntdLabor", new { id = ontdLabor.ID }, ConvertToDto(ontdLabor));
        }

        // DELETE: api/OntdLabor/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LaborDto>> DeleteOntdLabor(int id)
        {
            var ontdLabor = await _ontdLabors.FirstOrDefaultAsync(m => m.ID == id);
            if (ontdLabor == null)
            {
                return NotFound();
            }

            _ontdLabors.Remove(ontdLabor);
            await _ontdLabors.SaveChangesAsync();

            return ConvertToDto(ontdLabor);
        }

        private bool OntdLaborExists(int id)
        {
            return _ontdLabors.Any(e => e.ID == id);
        }
    }
}
