using System;
using System.Collections.Generic;
using McRobbie.Com;

namespace MVCApp.Models
{
    public class HomeIndexViewModel
    {
        public string Heading { get; set; }

        public IList<Character> Characters { get; set; }
    }
}