using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class UserEntity : IdentityUser
{

    [ProtectedPersonalData]
    public string FirstName { get; set; } = null!;

    [ProtectedPersonalData]
    public string LastName { get; set; } = null!;

    [ProtectedPersonalData]
    public string? ProfileImage { get; set; } = "avatar.jpg";

    [ProtectedPersonalData]
    public string? Bio { get; set; }

    public ICollection<AddressEntity> Addresses { get; set; } = new List<AddressEntity>();

}
