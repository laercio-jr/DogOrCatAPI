using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogOrCat.Models
{
    public class Cat
    {
        public string[]? breeds { get; set; }
        public string? id { get; set; }
        public string url { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
    }
}
