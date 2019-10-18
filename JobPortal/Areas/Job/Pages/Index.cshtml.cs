﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data;
using JobPortal.RepositoryPattern;
using Models;

namespace JobPortal.Areas.Job.Pages
{
    public class IndexModel : PageModel
    {
        private readonly JobPortal.Data.ApplicationDbContext _context;
        private readonly IEFRepository repository;

        public IndexModel(JobPortal.Data.ApplicationDbContext context, IEFRepository repository)
        {
            _context = context;
            this.repository = repository;
        }

        [BindProperty]
        public IList<Models.Job> Job { get; set; }

        public async Task OnGetAsync()
        {
            Job = await _context.Job.ToListAsync();
        }

        [BindProperty(SupportsGet = true)]
        public string term { get; set; }

        public IList<Models.Job> Jobs { get; set; }

        public JsonResult OnGetJobs()
        {
            try
            {
                if (!string.IsNullOrEmpty(term.ToLower()))
                {
                    //Job = repository.GetJobs().Where(x => x.Title.StartsWith(term)).ToList();        
                    Job = _context.Job.Where(x => x.Title.StartsWith(term)).ToList();
                }
            }
            catch (Exception)
            {
                Job = _context.Job.ToList();              
               
            }
           
            return new JsonResult(Job);
        }

    }
}
