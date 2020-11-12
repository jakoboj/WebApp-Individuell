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

            var cat1 = new Categories
            {
                CId = 1,
                Category = "Generell"
            };

            var cat2 = new Categories
            {
                CId = 2,
                Category = "Bestilling"
            };

            var cat3 = new Categories
            {
                CId = 3,
                Category = "Avgang"
            };

            var cat4 = new Categories
            {
                CId = 4,
                Category = "Stasjon"
            };

            var cat5 = new Categories
            {
                CId = 5,
                Category = "Nytt spørsmål"
            };

            db.Categories.Add(cat1);
            db.Categories.Add(cat2);
            db.Categories.Add(cat3);
            db.Categories.Add(cat4);
            db.Categories.Add(cat5);

            var qst1 = new Questions
            {
                Id = 1,
                Question = "Kan man bestille billett samme dag som billetten brukes?",
                Answer = "Ja, men billetten kan ikke refunderes senere enn 24 timer før bruk",
                Category = cat1,
                ThumbsUp = 0,
                ThumbsDown = 0
            };

            var qst2 = new Questions
            {
                Id = 2,
                Question = "Kan man endre avgang?",
                Answer = "Ja",
                Category = cat2,
                ThumbsUp = 0,
                ThumbsDown = 0
            };

            var qst3 = new Questions
            {
                Id = 3,
                Question = "Er avgangen den beste avgangen?",
                Answer = "Det kommer an på den enkelte",
                Category = cat3,
                ThumbsUp = 0,
                ThumbsDown = 0
            };

            var qst4 = new Questions
            {
                Id = 4,
                Question = "Kan man bestille billett samme dag som billetten brukes?",
                Answer = "Ja, men billetten kan ikke refunderes senere enn 24 timer før bruk",
                Category = cat4,
                ThumbsUp = 0,
                ThumbsDown = 0
            };

            db.Questions.Add(qst1);
            db.Questions.Add(qst2);
            db.Questions.Add(qst3);
            db.Questions.Add(qst4);

            db.SaveChanges();
        }
    }
}
