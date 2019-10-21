using System;
using System.ComponentModel.DataAnnotations;

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
 
        public AppUser AppUser { get; set; }
    }
}
