using Microsoft.AspNetCore.Identity;
using Physio.Domain.Enums;

namespace Physio.Domain.Entities;

public class UserEntity : IdentityUser
{
    //1 to clinic
    //2 to professional
    //3 to patient
    public AccountTypeEnum LoginType { get; set; }
}
