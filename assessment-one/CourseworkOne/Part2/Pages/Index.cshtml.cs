using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Part2.Pages
{
    public class IndexModel : PageModel
    {
        private University context;
        public IEnumerable<Student> Students { get; set; }
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(University injectedContext, ILogger<IndexModel> logger)
        {
            context = injectedContext;
            _logger = logger;
        }

        public void OnGet()
        {
            ViewData["StudentInfo"] = "Matthew Crabtree (B00414581)";
            Students = context.Students.ToList();
        }
    }
}
