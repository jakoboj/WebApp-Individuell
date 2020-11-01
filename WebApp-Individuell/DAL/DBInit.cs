using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Individuell.Models;

namespace WebApp_Individuell.DAL
{
    public static class DBInit
    {
        public static void Seed(IApplicationBuilder app)
        {
            var serviceScope = app.ApplicationServices.CreateScope();

            var db = serviceScope.ServiceProvider.GetService<FAQContext>();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var faq1 = new FAQ
            {
                Id = 1,
                Question = "Kan jeg det?",
                Answer = "Ja",
                Category = "Avgang",
                Thumbs = 0
               
            };

            var faq2 = new FAQ
            {
                Id = 2,
                Question = "Dersom jeg kjøper en billett nå, hvor lang tid kan jeg vente før jeg avbestiller?",
                Answer = "Du kan avbestille helt frem til tidspunktet billetten skal brukes, men pengene returneres ikke dersom du avbestiller senere enn 24 timer før billettstart",
                Category = "Bestilling",
                Thumbs = 0
            };

            db.FAQs.Add(faq1);
            db.FAQs.Add(faq2);

            db.SaveChanges();
        }
    }
}
