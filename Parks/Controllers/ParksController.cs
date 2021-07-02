using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkApi.Models;

namespace ParkApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ParksController : ControllerBase
  {
    private readonly ParkApiContext _db;

    public ParksController(ParkApiContext db)
    {
      _db = db;
    }

    // GET: api/Parks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Park>>> Get(string name, string parkType, string location)
    {
      var query = _db.Parks.AsQueryable();

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }

      if (parkType != null)
      {
        query = query.Where(entry => entry.ParkType == parkType);
      }

      if(location != null)
      {
        query = query.Where(entry => entry.Location == location);
      }

      return query.ToList();
    }
    
    //GET: api/Parks/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Park>> GetPark(int id)
    {
      var Park = await _db.Parks.FindAsync(id);

      if (Park == null)
      {
        return NotFound();
      }

      return Park;
    }

    // PUT: api/Parks/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPark(int id, Park Park)
    {
      if (id != Park.ParkId)
      {
        return BadRequest();
      }

      _db.Entry(Park).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ParkExists(id))
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

    // POST: api/Parks
    [HttpPost]
    public async Task<ActionResult<Park>> PostPark(Park Park)
    {
      _db.Parks.Add(Park);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetPark), new { id = Park.ParkId }, Park);
    }

    // DELETE: api/Parks/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePark(int id)
    {
      var Park = await _db.Parks.FindAsync(id);
      if (Park == null)
      {
        return NotFound();
      }

      _db.Parks.Remove(Park);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    private bool ParkExists(int id)
    {
      return _db.Parks.Any(e => e.ParkId == id);
    }
  }
}

