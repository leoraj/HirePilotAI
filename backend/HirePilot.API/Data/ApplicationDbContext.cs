using Microsoft.EntityFrameworkCore;
using HirePilot.API.Models;

namespace HirePilot.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Candidate> Candidates { get; set; }

    public DbSet<Job> Jobs { get; set; }
}