using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFStudyGuide.Classes.Other
{
    public class ProductSize
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal? PremiumPrice { get; set; }
        public decimal? ToppingPrice { get; set; }
        public bool? IsGlutenFree { get; set; }
    }
}
