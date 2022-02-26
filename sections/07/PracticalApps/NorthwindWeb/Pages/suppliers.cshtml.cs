using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crabtree.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
namespace NorthwindWeb.Pages
{
    public class SuppliersModel : PageModel
    {
        private readonly ILogger<SuppliersModel> _logger;
        public IEnumerable<string> Suppliers { get; set; }
        private Northwind dbContext;

        public SuppliersModel(Northwind injectedContext, ILogger<SuppliersModel> logger)
        {
            dbContext = injectedContext;
            _logger = logger;
        }

        public void OnGet()
        {
            ViewData["Title"] = "Northwind Web Site - Suppliers";
            Suppliers = dbContext.Suppliers.Select(s => s.CompanyName);
        }
    }
}
