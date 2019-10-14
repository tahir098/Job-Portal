using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data;
using Models;

namespace JobPortal.Areas.Identity.Pages.Employer
{
    public class DetailsModel : PageModel
    {
        private readonly JobPortal.Data.ApplicationDbContext _context;

        public DetailsModel(JobPortal.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Models.Job Job { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Job = await _context.Job.FirstOrDefaultAsync(m => m.JobId == id);

            if (Job == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
