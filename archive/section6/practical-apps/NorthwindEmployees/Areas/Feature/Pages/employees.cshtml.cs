using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Matt.Shared;

namespace MyFeature.Pages
{
    public class EmployeeModel : PageModel
    {
        private Northwind db;
        public EmployeeModel(Northwind injectedContext)
        {
            db = injectedContext;
        }
        
        public IEnumerable<Employee> Employees { get; set; }
        public void OnGet()
        {
            Employees = db.Employees.ToArray();
        }
    }
}
