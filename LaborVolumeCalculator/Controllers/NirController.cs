using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Dictionary;
using LaborVolumeCalculator.Models.Registers;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using NSwag.Annotations;
using LaborVolumeCalculator.DTO;
using AutoMapper;

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NirController : ControllerBase
    {
        private readonly LVCContext _context;
        private readonly IMapper _mapper;

        public NirController(LVCContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }


        /// <summary>
        ///     Возвращает добавленные к НИР этапы, по идентификатору НИР
        /// </summary>
        /// <param name="nirId"> Идентификатор НИР, тип: int</param>
        /// <returns> Список этапов НИР. тип: NirStage[] </returns>
        [HttpGet("{nirId}/[action]")]
        public async Task<ActionResult<IEnumerable<NirStageDto>>> Stages(int nirId)
        {
            var nirStage = await _context.Nirs.FindAsync(nirId);

            if (nirStage == null)
            {
                return NotFound();
            }

            var stages = await _context.NirStageRegs
                .Include(reg => reg.Stage)
                .Where(reg => reg.NirID == nirId)
                .Select(reg => reg.Stage)
                .OrderBy(stage => stage.Name)
                .AsNoTracking()
                .ToListAsync();

            var stagesDto = _mapper.Map<IList<NirStage>, IEnumerable<NirStageDto>>(stages);
            return stagesDto.ToList();
        }

        /// <summary>
        ///     Возвращает список всех возможных этапов, без привязки к конкретной НИР
        /// </summary>
        /// <returns> список НИР, тип: NirStage[]</returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<NirStage>>> NirStages()
        {
            return await _context.NirStages.ToListAsync();
        }

        // GET: api/NirController
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NirDto>>> GetNirs()
        {
            var nirs = await _context.Nirs
                .Include(n => n.NirInnovationProperty)
                .Include(n => n.NirScale)
                .ToListAsync();
            
            var nirsDto = ConvertToDto(nirs).ToList();
            return nirsDto;
        }

        // GET: api/NirController/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NirDto>> GetNir(int id)
        {
            var nir = await _context.Nirs
                .Include(n => n.NirInnovationProperty)
                .Include(n => n.NirScale)
                .FirstOrDefaultAsync(n => n.ID == id);

            if (nir == null)
            {
                return NotFound();
            }

            return ConvertToDto(nir);
        }

        // PUT: api/NirController/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNir(int id, NirDto nirDto)
        {
            if (id != nirDto.ID)
            {
                return BadRequest();
            }

            var nir = ConvertFromDto(nirDto);
            _context.Entry(nir).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NirExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/NirController
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NirDto>> PostNir(NirDto nirDto)
        {
            var nir = ConvertFromDto(nirDto);
            _context.Nirs.Add(nir);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNir", new { id = nir.ID }, ConvertToDto(nir));
        }

        // DELETE: api/NirController/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NirDto>> DeleteNir(int id)
        {
            var nir = await _context.Nirs.FindAsync(id);
            if (nir == null)
            {
                return NotFound();
            }

            _context.Nirs.Remove(nir);
            await _context.SaveChangesAsync();

            return ConvertToDto(nir);
        }

        private bool NirExists(int id)
        {
            return _context.Nirs.Any(e => e.ID == id);
        }

        private IEnumerable<NirDto> ConvertToDto(List<Nir> nirs)
        {
            return _mapper.Map<IList<Nir>, IEnumerable<NirDto>>(nirs);
        }

        private NirDto ConvertToDto(Nir nir)
        {
            return _mapper.Map<Nir, NirDto>(nir);
        }

        private Nir ConvertFromDto(NirDto nirDto)
        {
            return _mapper.Map<NirDto, Nir>(nirDto);
        }
    }
}