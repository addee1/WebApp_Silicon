using Infrastructure_API.Contexts;
using Infrastructure_API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API.Dtos;

namespace Web_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController(DataContextApi context) : ControllerBase
{
    private readonly DataContextApi _context = context;


    [HttpPost]
    public async Task<IActionResult> Create(CourseDto dto)
    {
        if (ModelState.IsValid)
        {
            if (! await _context.Courses.AnyAsync(x => x.Title == dto.Title))
            {
                var courseEntity = new CourseEntity
                {
                    Title = dto.Title,
                    Author = dto.Author,
                    IsBestseller = dto.IsBestseller,
                    DiscountPrice = dto.DiscountPrice,
                    OriginalPrice = dto.OriginalPrice,
                    LikesInNumbers = dto.LikesInNumbers,
                    LikesInProcent = dto.LikesInProcent,
                    Hours = dto.Hours,
                    ImageName = dto.ImageName,
                };
                _context.Courses.Add(courseEntity);
                await _context.SaveChangesAsync();

                return Created("", null);
            }

            return Conflict();
        }

        return BadRequest();
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var courses = await _context.Courses.ToListAsync();
        return Ok(courses);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(int id)
    {
        var coursesEntity = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
        if (coursesEntity != null)
        {
            return Ok(coursesEntity);
        }

        return NotFound();
        
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOne(int id)
    {
        var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
        if (course == null)
        {
            return NotFound();
        }

        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();

        return NoContent();
    }

}
