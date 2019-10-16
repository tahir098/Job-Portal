using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data;
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

        public IList<Models.Job> Job { get;set; }

        public async Task OnGetAsync()
        {
            Job = await _context.Job.ToListAsync();
        }
    }
}
