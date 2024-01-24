using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment2_WebServerAppDev.Data;
using Assignment2_WebServerAppDev.Models;
using Assignment2_WebServerAppDev.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Assignment2_WebServerAppDev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HobbiesController : ControllerBase
    {
        private readonly DBContext _context;
        IValidator _validator;

        public HobbiesController(DBContext context, IValidator Validator)
        {
            _context = context;
            _validator = Validator;
        }

        // GET: api/Hobbies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hobbies>>> Gethobbies()
        {
            if (!_validator.IsValid("test"))
            {
                return BadRequest();
            }

            return await _context.hobbies.ToListAsync();
        }

        // GET: api/Hobbies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hobbies>> GetHobbies(int id)
        {
            var hobbies = await _context.hobbies.FindAsync(id);

            if (hobbies == null)
            {
                return NotFound();
            }

            return hobbies;
        }

        // PUT: api/Hobbies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHobbies(int id, Hobbies hobbies)
        {
            if (id != hobbies.HobbiesId)
            {
                return BadRequest();
            }

            _context.Entry(hobbies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HobbiesExists(id))
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

        // POST: api/Hobbies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hobbies>> PostHobbies(Hobbies hobbies)
        {
            _context.hobbies.Add(hobbies);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHobbies", new { id = hobbies.HobbiesId }, hobbies);
        }

        // DELETE: api/Hobbies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHobbies(int id)
        {
            var hobbies = await _context.hobbies.FindAsync(id);
            if (hobbies == null)
            {
                return NotFound();
            }

            _context.hobbies.Remove(hobbies);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HobbiesExists(int id)
        {
            return _context.hobbies.Any(e => e.HobbiesId == id);
        }
    }
}
