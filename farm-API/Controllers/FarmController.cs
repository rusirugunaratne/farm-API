using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using farm_API.Models;

namespace farm_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmController : ControllerBase
    {
        private readonly FinFarmerDbContext _context;

        public FarmController(FinFarmerDbContext context)
        {
            _context = context;
        }

        // GET: api/Farm
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Farm>>> GetFarms()
        {
            return await _context.Farms.ToListAsync();
        }

        // GET: api/Farm/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Farm>> GetFarm(int id)
        {
            var farm = await _context.Farms.FindAsync(id);

            if (farm == null)
            {
                return NotFound();
            }

            return farm;
        }

        // PUT: api/Farm/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFarm(int id, Farm farm)
        {
            if (id != farm.FarmId)
            {
                return BadRequest();
            }

            _context.Entry(farm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FarmExists(id))
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

        // POST: api/Farm
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Farm>> PostFarm(Farm farm)
        {
            _context.Farms.Add(farm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFarm", new { id = farm.FarmId }, farm);
        }

        // DELETE: api/Farm/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFarm(int id)
        {
            var farm = await _context.Farms.FindAsync(id);
            if (farm == null)
            {
                return NotFound();
            }

            _context.Farms.Remove(farm);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FarmExists(int id)
        {
            return _context.Farms.Any(e => e.FarmId == id);
        }
    }
}
