using Microsoft.EntityFrameworkCore;
using StarWarsPlanets.Api.Models;

namespace StarWarsPlanets.Api.Data;

public class StarWarsDbContext : DbContext
{
    public StarWarsDbContext(DbContextOptions<StarWarsDbContext> options) : base(options)
    {
    }

    public DbSet<Planet> Planets => Set<Planet>();
}
