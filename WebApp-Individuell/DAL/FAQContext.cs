using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Individuell.Models;

namespace WebApp_Individuell.DAL
{
    public class Questions
    {
        [Key]
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        virtual public Categories Category { get; set; }
        public int ThumbsUp { get; set; }
        public int ThumbsDown { get; set; }
    }

    public class Categories
    {
        [Key]
        public int CId { get; set; }
        public string Category { get; set; }
        virtual public List<Questions> Questions { get; set; }
    }

    public class FAQContext : DbContext
    {
        public FAQContext (DbContextOptions<FAQContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Questions> Questions { get; set; }
        public DbSet<Categories> Categories { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
