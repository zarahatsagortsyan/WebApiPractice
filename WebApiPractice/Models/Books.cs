using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPractice.Models
{
    public class Books
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string  Descriprion { get; set; }
        public string  Author { get; set; }
        public decimal Price { get; set; }
    }
}
