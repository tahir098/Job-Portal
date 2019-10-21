using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
   public class AppUser : IdentityUser
    {
        public string CV_Url { get; set; }

    }
}
