using Microsoft.AspNetCore.Mvc;
using HirePilot.API.Data;
using HirePilot.API.Models;

namespace HirePilot.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public JobsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Jobs.ToList());
    }

    [HttpPost]
    public IActionResult Create(Job job)
    {
        _context.Jobs.Add(job);

        _context.SaveChanges();

        return Ok(job);
    }
}
