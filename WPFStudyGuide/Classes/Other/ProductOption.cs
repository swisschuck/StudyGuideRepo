using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFStudyGuide.Classes.Other
{
    public class ProductOption
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int Factor { get; set; }
        public bool IsPizzaOption { get; set; }
        public bool IsSaladOption { get; set; }
    }
}
