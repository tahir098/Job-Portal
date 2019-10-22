using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;

namespace JobPortal.Areas.Employer.Pages
{
    public class IndexModel : PageModel
    {
        private readonly JobPortal.Data.ApplicationDbContext _context;

        public IndexModel(JobPortal.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.Job> Job { get; set; }

        // [BindProperty]
        public IdentityUser AppUser { get; set; }


        public async Task OnGetAsync()
        {
            //   var jobs = await _context.Job.FirstOrDefaultAsync(x => x.UserId == AppUser.Id);
            AppUser = _context.Users.SingleOrDefault(x => x.Email == User.Identity.Name);

          //  Job = _context.UserJob.FirstOrDefault(x => x.UserId == AppUser.Id);

            // var job = await _context.UserJob.FirstOrDefaultAsync(x => x.AppUser == AppUser);

            //   var result = await _context.Job.FindAsync(job.JobId);

            //  result = Job.ToString();
            //     Job = await _context.Job.ToListAsync();

            Job = await _context.Job.ToListAsync();
        }
    }
}
