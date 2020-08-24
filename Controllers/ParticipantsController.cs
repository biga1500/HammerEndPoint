using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HammerEndPoint.Models;

namespace HammerEndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly ParticipantContext _context;

        public ParticipantsController(ParticipantContext context)
        {
            _context = context;
        }
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
             
            })
            .ToArray();
        }
        // GET: api/Participants
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Participant>>> GetParcticipants()
        {
            return await _context.Parcticipants.ToListAsync();
        }

        // GET: api/Participants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Participant>> GetParticipant(long id)
        {
            var participant = await _context.Parcticipants.FindAsync(id);

            if (participant == null)
            {
                return NotFound();
            }

            return participant;
        }

        // PUT: api/Participants/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipant(long id, Participant participant)
        {
            if (id != participant.Id)
            {
                return BadRequest();
            }

            _context.Entry(participant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantExists(id))
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

        // POST: api/Participants
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("api/Participants")]
        public async Task<ActionResult<Participant>> PostParticipant(Participant participant)
        {
            _context.Parcticipants.Add(participant);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetParticipant", new { id = participant.Id }, participant);
            return CreatedAtAction(nameof(GetParticipant), new { id = participant.Id }, participant);
        }

        // DELETE: api/Participants/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Participant>> DeleteParticipant(long id)
        {
            var participant = await _context.Parcticipants.FindAsync(id);
            if (participant == null)
            {
                return NotFound();
            }

            _context.Parcticipants.Remove(participant);
            await _context.SaveChangesAsync();

            return participant;
        }

        private bool ParticipantExists(long id)
        {
            return _context.Parcticipants.Any(e => e.Id == id);
        }
    }
}
