using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    [Table("UserJob")]
    public class UserJob
    {
        ////[Key]
        ////public int Id { get; set; }

        [Required]
        // public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        [Required]
        // public int JobId { get; set; }
        public Job Job { get; set; }

        [Required]
        public string CV_Url { get; set; }

    }
}
