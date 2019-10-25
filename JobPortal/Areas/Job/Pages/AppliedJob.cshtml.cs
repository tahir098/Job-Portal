using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobPortal.Data;
using JobPortal.RepositoryPattern;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using JobPortal.Areas.Job;
using Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Areas.Job.Pages
{
    public class AppliedJobModel : PageModel
    {
        private readonly ApplicationDbContext context;


        public AppliedJobModel(ApplicationDbContext context)
        {
            this.context = context;
        }

          [BindProperty]
        public IList<UserJob> UserJob { get; set; }

      //  [BindProperty]
       // public IList<Models.Job> Job { get; set; }

        public IdentityUser AppUser { get; set; }
        public void OnGet()
        {
            AppUser = context.Users.SingleOrDefault(x => x.Email == User.Identity.Name);

            UserJob = context.UserJob.Where(x => x.UserId == AppUser.Id)
                .Include(x => x.Job)               
                .ToList();

            //var query = from job in context.Job
            //            join users in userJobs on job.JobId equals users.JobId
            //            select new { Job = job };

        }


    }
}
