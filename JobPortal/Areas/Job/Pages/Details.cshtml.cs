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
using Microsoft.AspNetCore.Identity;

namespace JobPortal.Areas.Job.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly JobPortal.Data.ApplicationDbContext _context;
        [Obsolete]
        private readonly IHostingEnvironment env;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        [Obsolete]
        public DetailsModel(JobPortal.Data.ApplicationDbContext context, IHostingEnvironment env, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            this.env = env;
            this.userManager = userManager;
            this.signInManager = signInManager;
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

        [BindProperties]
        public class CvPostVm
        {
            public string AppUserId { get; set; }
            public int JobId { get; set; }
            public string CV_Url { get; set; }

        }
        [Obsolete]
        public async Task<IActionResult> OnPostCvAsync()
        {
            if (!ModelState.IsValid)
            {
                Message = "CV is required!";
                ModelState.AddModelError("", "CV is required");
            }
            else
            {
                var job = Job.JobId;
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                var userJob = _context.UserJob.Where(x => x.JobId == job).ToList();
                var result = userJob.FirstOrDefault(x => x.UserId == user.Id);

                if (result == null)
                {
                    var file = Path.Combine(env.ContentRootPath, "uploads", Cv.FileName);
                    using (var fileStream = new FileStream(file, FileMode.Create))
                    {
                        await Cv.CopyToAsync(fileStream);
                        var path = fileStream.Name.ToString();

                        var vm = new UserJob
                        {
                            UserId = user.Id,
                            CV_Url = path,
                            JobId = job
                        };

                        _context.UserJob.Add(vm);
                        await _context.SaveChangesAsync();
                    }
                    Message = "Applied Successfuly";
                    return RedirectToPage("./Index");
                }
                else
                {
                    Message = "You already applied for this job!";
                }

            }
            return Page();
        }
    }
}
