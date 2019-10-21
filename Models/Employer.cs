using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
   
    public class Employer : IdentityUser
    {
      
        public int EmployerId { get; set; }
       

    }
}