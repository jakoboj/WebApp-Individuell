using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Individuell.Models
{
    public class FAQ
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Category { get; set; }
        public int Thumbs { get; set; }
    }
}
