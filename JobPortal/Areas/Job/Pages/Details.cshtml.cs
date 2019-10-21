using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data;
using Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Areas.Job.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly JobPortal.Data.ApplicationDbContext _context;
        private readonly IHostingEnvironment env;

        public DetailsModel(JobPortal.Data.ApplicationDbContext context, IHostingEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        [BindProperty]
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

        [TempData]
        public string Message { get; set; }
        public bool ShowMessage => !string.IsNullOrEmpty(Message);

        [BindProperty]
        [Required]
        public IFormFile Cv { get; set; }

        public async Task<IActionResult> OnPostCvAsync()
        {
            if (!ModelState.IsValid)
            {

                Message = "CV is required!";
                ModelState.AddModelError("", "CV is required");
            }
            else
            {
                try
                {
                    var file = Path.Combine(env.ContentRootPath, "uploads", Cv.FileName);
                    using (var fileStream = new FileStream(file, FileMode.Create))
                    {
                        await Cv.CopyToAsync(fileStream);
                    }
                    Message = "CV successfuly uploaded!";
                    return RedirectToPage("./Index");
                }
                catch (Exception)
                {
                }
            }
            return Page();
            //  return RedirectToPage($"Details?id="+ Job.JobId);
            // return RedirectToPage($"Details?id={Job.JobId}");

        }
    }
}
