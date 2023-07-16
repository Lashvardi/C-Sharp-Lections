using LMS.Data;
using LMS.DTO;
using LMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SchoolController : Controller
{
    private readonly DataContext _context;
    
    public SchoolController(DataContext context)
    {
        _context = context;
    }

    [HttpPost("register-principal")]
    public async Task<IActionResult> RegisterPrincipal([FromForm] PrincipalDto principalDto)
    {
        // Check if a principal already exists in the database
        var existingPrincipal = await _context.Principals.FirstOrDefaultAsync();
        if (existingPrincipal != null)
        {
            return BadRequest("A principal is already registered.");
        }

        var principal = new Principal()
        {
            Id = Guid.NewGuid(),
            Name = principalDto.Name,
            Email = principalDto.Email,
            Password = principalDto.Password,
            IdentityNumber = principalDto.IdentityNumber,
            SchoolToken = Principal.GenerateToken(),
            SchoolId = null,
        };

        await _context.Principals.AddAsync(principal);
        await _context.SaveChangesAsync();

        return Ok(new { token = principal.SchoolToken });
    }
    
    [HttpPost("login-principal")]
    public async Task<IActionResult> LoginPrincipal([FromForm] PrincipalDto principalDto)
    {
        var principal = await _context.Principals.FirstOrDefaultAsync();
        if (principal == null)
        {
            return BadRequest("A principal is not registered.");
        }

        if (principal.Email != principalDto.Email)
        {
            return BadRequest("Invalid email.");
        }

        if (principal.Password != principalDto.Password)
        {
            return BadRequest("Invalid password.");
        }

        return Ok(new { token = principal.SchoolToken });
    }
    
    [HttpPost("register-school")]
    // [Authorize("schooltoken")]
    public async Task<IActionResult> RegisterSchool([FromForm] SchoolDto schoolDto, string token)
    {
        
        // Verify the token and perform necessary authorization checks
        if (string.IsNullOrEmpty(token) || !(await IsValidSchoolToken(token)))
        {
            return Unauthorized("Invalid or missing school token.");
        }

        var principal = await _context.Principals.FirstOrDefaultAsync();
        if (principal == null)
        {
            return BadRequest("A principal is not registered.");
        }

        if (principal.SchoolId != null)
        {
            return BadRequest("A school is already registered.");
        }

        var school = new School()
        {
            SchoolId = Guid.NewGuid(),
            Name = schoolDto.Name,
            Address = schoolDto.Address,
            PrincipalId = principal.Id,
            District = schoolDto.District,
        };

        await _context.Schools.AddAsync(school);
        await _context.SaveChangesAsync();

        principal.SchoolId = school.SchoolId;
        school.PrincipalId = principal.Id;
        await _context.SaveChangesAsync();

        return Ok(new { school, principal.Name });
    }
    
    private async Task<bool> IsValidSchoolToken(string token)
    {
        var principal = await _context.Principals.FirstOrDefaultAsync();
        if (principal == null)
        {
            return false;
        }

        return principal.SchoolToken == token;
    }


}