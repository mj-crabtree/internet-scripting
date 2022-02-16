using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Matt.Shared;

namespace MyFeature.Pages
{
    public class ProductsModel : PageModel
    {
        private Northwind db;
        public ProductsModel(Northwind injectedContext)
        {
            db = injectedContext;
        }
        public IEnumerable<Product> Products { get; set; }
        public void OnGet()
        {
            Products = db.Products.ToArray();
        }
    }
}
