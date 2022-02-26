using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crabtree.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace NorthwindEmployees.Areas.CrabtreeFeatures.Pages
{
    public class EmployeePageModel : PageModel
    {
        private Northwind dbContext;
        public IEnumerable<Employee> Employees { get; set; }
        private readonly ILogger<EmployeePageModel> _logger;

        public EmployeePageModel(ILogger<EmployeePageModel> logger, Northwind injectedContext)
        {
            _logger = logger;
            dbContext = injectedContext;
        }

        public void OnGet()
        {
            Employees = dbContext.Employees.ToArray();
        }
    }
}
