using Microsoft.AspNetCore.Mvc;
using HirePilot.API.Models;
using HirePilot.API.Data;

namespace HirePilot.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CandidatesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CandidatesController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Candidates.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var candidate = _context.Candidates.Find(id);

        if (candidate == null)
        {
            return NotFound();
        }

        return Ok(candidate);
    }

    [HttpPost]
    public IActionResult Create(Candidate candidate)
    {
        _context.Candidates.Add(candidate);

        _context.SaveChanges();

        return Ok(candidate);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Candidate updatedCandidate)
    {
        var candidate = _context.Candidates.Find(id);

        if (candidate == null)
        {
            return NotFound();
        }

        candidate.Name = updatedCandidate.Name;
        candidate.Email = updatedCandidate.Email;
        candidate.ExperienceYears = updatedCandidate.ExperienceYears;
        candidate.Skills = updatedCandidate.Skills;
        candidate.MatchScore = updatedCandidate.MatchScore;
        candidate.Status = updatedCandidate.Status;

        _context.SaveChanges();

        return Ok(candidate);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var candidate = _context.Candidates.Find(id);

        if (candidate == null)
        {
            return NotFound();
        }

        _context.Candidates.Remove(candidate);

        _context.SaveChanges();

        return Ok();
    }
}