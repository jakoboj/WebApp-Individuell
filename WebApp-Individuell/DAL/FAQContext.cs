using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Individuell.Models;

namespace WebApp_Individuell.DAL
{
    public class FAQContext : DbContext
    {
        public FAQContext (DbContextOptions<FAQContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<FAQ> FAQs { get; set; }
    }
}
