using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text.Json.Serialization;
using LMS.DTO;

namespace LMS.Models;

public class Principal
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string IdentityNumber { get; set; }
    public string SchoolToken { get; set; }

    // Nullable SchoolId
    public Guid? SchoolId { get; set; }
    [JsonIgnore]
    public School School { get; set; }
    
    
    public static string GenerateToken()
    {
        using (var rng = new RNGCryptoServiceProvider())
        {
            var bytes = new byte[32];
            rng.GetBytes(bytes);
            var token = Convert.ToBase64String(bytes);
            return token;
        }
    }
}