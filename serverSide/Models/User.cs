using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace serverSide.Models
{
    public class User : IdentityUser
    {
        public string? UserId { get; set; }
        [StringLength(20)]
        public required string Firstname { get; set; }
        [StringLength(20)]
        public required string Middlename { get; set; }
        [StringLength(20)]
        public required string Lastname { get; set; }
        public string? Token { get; set; }
    }
}
