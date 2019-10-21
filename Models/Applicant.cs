using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
  
    public class Applicant 
    {
        
        public int ApplicantId { get; set; }
       
        public string Cv_Url { get; set; }

        


    }
}
