using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebGoT.Models.Character
{
    public class IndexViewModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }

        public IndexViewModel(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}