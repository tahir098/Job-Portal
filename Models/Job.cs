using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Job
    {
        public int JobId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public DateTime PostDate { get; set; } = DateTime.Now;

        [ForeignKey("AppUser")]
        public string UserId { get; set; }
        public IdentityUser AppUser { get; set; }
    }
}
