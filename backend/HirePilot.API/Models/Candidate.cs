namespace HirePilot.API.Models;

public class Candidate
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public string Email { get; set; } = "";

    public int ExperienceYears { get; set; }

    public string Skills { get; set; } = "";

    public double MatchScore { get; set; }

    public string Status { get; set; } = "New";
}