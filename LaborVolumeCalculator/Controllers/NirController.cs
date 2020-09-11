using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Dictionary;
using LaborVolumeCalculator.Models.Registers;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using NSwag.Annotations;

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NirController : ControllerBase
    {
        private readonly LVCContext _context;

        public NirController(LVCContext context)
        {
            _context = context;
        }


        /// <summary>
        ///     Возвращает добавленные к НИР этапы, по идентификатору НИР
        /// </summary>
        /// <param name="nirId"> Идентификатор НИР, тип: int</param>
        /// <returns> Список этапов НИР. тип: NirStage[] </returns>
        [HttpGet("{nirId}/[action]")]
        public async Task<ActionResult<IEnumerable<NirStage>>> Stages(int nirId)
        {
            var nirStage = await _context.Nirs.FindAsync(nirId);

            if (nirStage == null)
            {
                return NotFound();
            }

            return await _context.NirStageRegs
                .Include(reg => reg.NirStage)
                .Where(reg => reg.NirID == nirId)
                .Select(reg => reg.NirStage)
                .OrderBy(stage => stage.Name)
                .AsNoTracking()
                .ToListAsync();
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
        public async Task<ActionResult<IEnumerable<Nir>>> GetNirs()
        {
            return await _context.Nirs.ToListAsync();
        }

        // GET: api/NirController/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nir>> GetNir(int id)
        {
            var nir = await _context.Nirs.FindAsync(id);

            if (nir == null)
            {
                return NotFound();
            }

            return nir;
        }

        // PUT: api/NirController/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNir(int id, Nir nir)
        {
            if (id != nir.ID)
            {
                return BadRequest();
            }

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
        public async Task<ActionResult<Nir>> PostNir(Nir nir)
        {
            _context.Nirs.Add(nir);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNir", new { id = nir.ID }, nir);
        }

        // DELETE: api/NirController/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Nir>> DeleteNir(int id)
        {
            var nir = await _context.Nirs.FindAsync(id);
            if (nir == null)
            {
                return NotFound();
            }

            _context.Nirs.Remove(nir);
            await _context.SaveChangesAsync();

            return nir;
        }

        private bool NirExists(int id)
        {
            return _context.Nirs.Any(e => e.ID == id);
        }
    }
}