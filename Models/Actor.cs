using System.Text.Json.Serialization;

namespace MyFirstApi.Models;

public class Actor
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    [JsonIgnore]
    public List<Movie> Movies { get; set; } = new();
    [JsonIgnore]
    public List<MovieActor> MovieActors { get; set; } = new();
}