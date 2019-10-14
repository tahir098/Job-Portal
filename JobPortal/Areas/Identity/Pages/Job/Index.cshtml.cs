using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data;
using Models;
using JobPortal.RepositoryPattern;

namespace JobPortal.Areas.Identity.Pages.Job
{
    public class IndexModel : PageModel
    {
       
        private readonly EFRepository repository;

        public IndexModel(EFRepository repository)
        {
            
            this.repository = repository;
        }

        public IList<Models.Job> Job { get;set; }

        public IList<Models.Job> OnGet()
        {
            Job = repository.GetJobs();
            return Job;
        }
    }
}
