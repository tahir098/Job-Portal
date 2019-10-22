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


        //when uncomment then cv does not post.
        //[BindProperty]
        //public UserJob UserJob { get; set; }


        // public UserJob UserJob { get; set; }


        #region testing

        //new class for testing

        [BindProperties]
        public class CvPostVm
        {
            public string AppUserId { get; set; }
            public int JobId { get; set; }
            public string CV_Url { get; set; }

        }
        #endregion
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
                //we get the jobId
                var job = Job.JobId;
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                //var user = User.Identity.Name;
                var file = Path.Combine(env.ContentRootPath, "uploads", Cv.FileName);
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await Cv.CopyToAsync(fileStream);
                    var path = fileStream.Name.ToString();

                    var vm = new CvPostVm
                    {
                        CV_Url = path,
                        JobId = job,
                        AppUserId = user.Id.ToString()
                    };

                    AppUser appUser = new AppUser();
                    appUser.Id = vm.AppUserId;

                    Models.Job job1 = new Models.Job();
                    job1.JobId = vm.JobId;

                    var userJobs = new UserJob()
                    {
                        AppUser = appUser,
                        Job = job1,
                        CV_Url = vm.CV_Url
                    };

                   
                    _context.UserJob.Add(userJobs);
                    await _context.SaveChangesAsync();

                }
                Message = "Applied Successfuly";
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
