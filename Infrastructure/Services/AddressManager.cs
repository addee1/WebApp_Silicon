using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AddressManager(DataContext context)
{
    private readonly DataContext _context = context;

    // Inom AddressManager
    public async Task<AddressEntity> GetUserAddressAsync(string userId)
    {
        return await _context.Addresses.FirstOrDefaultAsync(a => a.UserId == userId);
    }



    public async Task UpdateOrCreateAddressAsync(string userId, string streetName, string postalCode, string city)
    {
        var address = await _context.Addresses.FirstOrDefaultAsync(a => a.UserId == userId);

        if (address != null)
        {
            // Uppdatera befintlig adress
            address.StreetName = streetName;
            address.PostalCode = postalCode;
            address.City = city;
        }
        else
        {
            // Skapa en ny adress
            address = new AddressEntity
            {
                UserId = userId,
                StreetName = streetName,
                PostalCode = postalCode,
                City = city
            };
            _context.Addresses.Add(address);
        }

        await _context.SaveChangesAsync();
    }


}
