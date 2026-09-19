using System.ComponentModel.DataAnnotations.Schema;

namespace StarWarsPlanets.Blazor.Models;

public class Planet
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int RotationPeriod { get; set; }
    public int OrbitalPeriod { get; set; }
    public string? Diameter { get; set; }
    public string? Climate { get; set; }
    public string? Gravity { get; set; }
    public string? Terrain { get; set; }
    public string? SurfaceWater { get; set; }
    public int Population { get; set; }
}
