using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace NorthwindWeb.Pages
{
    public class SuppliersModel : PageModel
    {
        private readonly ILogger<SuppliersModel> _logger;
        public IEnumerable<string> Suppliers { get; set; }

        public SuppliersModel(ILogger<SuppliersModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            ViewData["Title"] = "Northwind Web Site - Suppliers";
            Suppliers = new[]
            {
                "Alpha Co", "Beta Limited", "Gamma Corp"
            };
        }
    }
}
