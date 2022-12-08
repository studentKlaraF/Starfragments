using Microsoft.AspNetCore.Identity;

namespace SeminarskaNaloga.Models;

public class AppUser : IdentityUser
{
    #nullable enable
     public string? ime { get; set; }
     public string? priimek { get; set; }
     public string? mail { get; set; }
}