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

namespace JobPortal.Areas.Identity.Pages.Employer
{
    public class CreateModel : PageModel
    {
  
        private readonly IEFRepository repository;

        public CreateModel(IEFRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.Job Job { get; set; }

        public Models.Employer Employer { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Cannot create a job. Try again later");
                return Page();
            }

            repository.Add(Job);
            repository.SaveChanges();


            return RedirectToPage("./Index");
        }
    }
}
