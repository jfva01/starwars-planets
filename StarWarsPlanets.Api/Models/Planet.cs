using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace StarWarsPlanets.Api.Models;

public class Planet
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    [Column("rotation_period")]
    public int RotationPeriod { get; set; }
    [Column("orbital_period")]
    public int OrbitalPeriod { get; set; }
    public string? Diameter { get; set; }
    public string? Climate { get; set; }
    public string? Gravity { get; set; }
    public string? Terrain { get; set; }
    [Column("surface_water")]
    public string? SurfaceWater { get; set; }
    public int Population { get; set; }
}
