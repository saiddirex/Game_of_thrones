using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Character = WebGoT.Models.Character;

namespace WebGoT.Models.House
{
    public class IndexViewModel
    {
        public String Name { get; set; }
        public int NumberOfUnities { get; set; }
        public List<Character.IndexViewModel> Housers { get; set; }

        public IndexViewModel(String name, int numberOfUnities)
        {
            this.Name = name;
            this.NumberOfUnities = numberOfUnities;
            this.Housers = new List<Character.IndexViewModel>();
        }
    }
}