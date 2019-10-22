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
        [Key]
        public int Id { get; set; }
        

        //using int Id's so tables are not joined and so db is not performing extra queries.

        [ForeignKey("AppUser")]
        [Required]
        public string UserId { get; set; }
        public AppUser AppUser { get; set; }

        [ForeignKey("Job")]
        [Required]
        public int JobId { get; set; }
        public Job Job { get; set; }

        [Required]
        public string CV_Url { get; set; }

    }
}
