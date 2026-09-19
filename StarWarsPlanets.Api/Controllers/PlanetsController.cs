using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarWarsPlanets.Api.Data;
using StarWarsPlanets.Api.Models;
using StarWarsPlanets.Api.DTOs;

namespace StarWarsPlanets.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlanetsController : ControllerBase
{
    private readonly StarWarsDbContext _context;

    public PlanetsController(StarWarsDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Planet>>> GetPlanets()
    {
        var planets = await _context.Planets.ToListAsync();

        return Ok(planets);
    }

    [HttpPost]
    public async Task<ActionResult<Planet>> CreatePlanet(CreatePlanetDto dto)
    {
        var planet = new Planet
        {
            Name = dto.Name,
            RotationPeriod = dto.RotationPeriod,
            OrbitalPeriod = dto.OrbitalPeriod,
            Diameter = dto.Diameter,
            Climate = dto.Climate,
            Gravity = dto.Gravity,
            Terrain = dto.Terrain,
            SurfaceWater = dto.SurfaceWater,
            Population = dto.Population
        };
        _context.Planets.Add(planet);
        await _context.SaveChangesAsync();
        // (201) Indicamos correctamente que se creó un recurso nuevo
        return CreatedAtAction(
            nameof(GetPlanets), 
            new { id = planet.Id },
            planet);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlanet(int id)
    {
        var planet = await _context.Planets.FindAsync(id);

        if (planet == null)
        {
            return NotFound();
        }
        
        _context.Planets.Remove(planet);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
