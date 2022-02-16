using System.Collections.Generic;
using McRobbie.Com;

namespace mvc.Models
{
    public class HomeIndexViewModel
    {
        public string Heading { get; set; }
        public IList<Character> Characters { get; set; }
        
    }
}