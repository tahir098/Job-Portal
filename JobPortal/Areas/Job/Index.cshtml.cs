using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data;
using JobPortal.RepositoryPattern;

namespace JobPortal.Areas.Job
{
    public class IndexModel : PageModel
    {
        private readonly JobPortal.Data.ApplicationDbContext _context;
        private readonly IEFRepository repository;

        public IndexModel(JobPortal.Data.ApplicationDbContext context,IEFRepository repository)
        {
            _context = context;
            this.repository = repository;
        }

        public IList<Models.Job> Job { get;set; }

        public async Task OnGetAsync()
        {
            Job = await _context.Job.ToListAsync();
        }

        //[BindProperty(SupportsGet =true)]
        //public string term { get; set; }

        //public async Task OnGetAsync()
        //{

        //   var job =  _context.Job.ToList();

        //    if (!string.IsNullOrEmpty(term))
        //    {
               
        //     //   job = job.Where(x => x.Title.StartsWith(term)).Select(x => x.Title).ToList();            //.Where(x => x.Title.StartsWith(term)).Select(x => x.Title).ToList();
        //        Job = job;
        //    }

           

        //}
        
    }
}
