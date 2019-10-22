using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using JobPortal.Data;
using Models;
using JobPortal.RepositoryPattern;
using Microsoft.AspNetCore.Identity;

namespace JobPortal.Areas.Employer.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IEFRepository repository;
        private readonly ApplicationDbContext context;

        public CreateModel(IEFRepository repository, ApplicationDbContext context)
        {
            this.repository = repository;
            this.context = context;
        }

        [BindProperty]
        public IdentityUser AppUser { get; set; }

        public IActionResult OnGet()
        {
            AppUser = context.Users.SingleOrDefault(x => x.Email == User.Identity.Name);
            return Page();
        }

        [BindProperty]
        public Models.Job Job { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Cannot create a job. Try again later");
                return Page();
            }

            Job.UserId = AppUser.Id;
            repository.Add(Job);
            repository.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
