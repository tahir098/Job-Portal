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

        public void OnGet()
        {
            AppUser = _context.Users.SingleOrDefault(x => x.Email == User.Identity.Name);
            Job = _context.Job.Where(x => x.UserId == AppUser.Id).ToList();
        }
    }
}
