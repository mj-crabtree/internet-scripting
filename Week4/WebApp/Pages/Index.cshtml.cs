using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using McRobbie.Com;

namespace WebApp.Pages
{
    public class CharactersModel : PageModel
    {
        public string Heading { get; set; }
        public IEnumerable<string> Characters { get; set; }

        public void OnGet() {
            Heading = "Simpsons Characters";
            // Characters = new [] { "Homer", "Marge", "Bart", "Lisa", "Maggie" };
            Simpsons db = new Simpsons();
            Characters = db.Characters.Select( c => c.Firstname + " " + c.Lastname );
        }
    }
}