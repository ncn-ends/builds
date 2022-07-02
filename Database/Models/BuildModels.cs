using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models;

public class BuildBO
{
    public int Id { get; set; }
    public string Title { get; set; } = "EMPTY TITLE";
    public bool Archived { get; set; }
}

internal class BuildDto
{
    public int Id { get; set; }
    public string Title { get; set; } = "EMPTY TITLE";
    public bool Archived { get; set; }
}