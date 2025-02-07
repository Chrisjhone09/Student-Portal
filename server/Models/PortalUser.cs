using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace server.Models
{
    public class PortalUser : IdentityUser
    {
        [Key]
        public int StudentId { get; set; }
        [StringLength(20)]
        public required string Firstname { get; set; }
        [StringLength(20)]
        public required string Middlename { get; set; }
        [StringLength(20)]
        public required string Lastname { get; set; }
        public required string Program {  get; set; }
        public string? Status { get; set; }
    }
}
