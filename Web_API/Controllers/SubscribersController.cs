using Infrastructure_API.Contexts;
using Infrastructure_API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API.Dtos;
namespace Web_API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class SubscribersController(DataContextApi context) : ControllerBase
{

    private readonly DataContextApi _context = context;

    [HttpPost]
    public async Task<IActionResult> Subscribe(SubscriberDto dto)
    {
        if (!await _context.Subscribers.AnyAsync(s => s.Email == dto.Email))
        {
            var subscriber = new SubscriberEntity { Email = dto.Email };
            _context.Subscribers.Add(subscriber);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Subscribe), new { id = subscriber.Id }, subscriber);
        }
        else
        {
            
            return Conflict("Subscriber already exists.");
        }


    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(int id)
    {
        var subscriberEntity = await _context.Subscribers.FirstOrDefaultAsync(x => x.Id == id);
        if (subscriberEntity == null)
        {
            return NotFound();
        }

        return Ok(subscriberEntity);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var subscribers = await _context.Subscribers.ToListAsync();
        return Ok(subscribers);
    }



    [HttpDelete("{email}")]
    public async Task<IActionResult> Unsubscribe(string email)
    {
        var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.Email == email);
        if (subscriber == null)
        {
            return NotFound();
        }

        _context.Subscribers.Remove(subscriber);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
