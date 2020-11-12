using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Individuell.Models;

namespace WebApp_Individuell.DAL
{
    public class FAQRepository : IFAQRepository
    {
        private readonly FAQContext _db;

        public FAQRepository(FAQContext db)
        {
            _db = db;
        }

        public async Task<List<FAQ>> HentAlle()
        {
            try
            {
                List<FAQ> alleFAQs = await _db.Questions.Select(f => new FAQ
                {
                    Id = f.Id,
                    Question = f.Question,
                    Answer = f.Answer,
                    Category = f.Category.Category,
                    ThumbsUp = f.ThumbsUp,
                    ThumbsDown = f.ThumbsDown
                }).ToListAsync();
                return alleFAQs;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> AskQuestion(FAQ innQuestion)
        {
            try
            {
                var nyttSpmRad = new Questions();
                nyttSpmRad.Question = innQuestion.Question;
                nyttSpmRad.Answer = "";
                var sjekkCat = await _db.Categories.FindAsync(innQuestion.CId);
                nyttSpmRad.Category = sjekkCat;
                nyttSpmRad.ThumbsUp = 0;
                nyttSpmRad.ThumbsDown = 0;


                _db.Questions.Add(nyttSpmRad);
                await _db.SaveChangesAsync();
                return true;
            } 
            catch
            {
                return false;
            }
        }

        public async Task<bool> EndreRating(FAQ endretRating)
        {
            try
            {
                var endreObjekt = await _db.Questions.FindAsync(endretRating.Id);
                endreObjekt.Question = endretRating.Question;
                endreObjekt.Answer = endretRating.Answer;
                endreObjekt.Category.Category = endretRating.Category;
                endreObjekt.ThumbsUp = endretRating.ThumbsUp;
                endreObjekt.ThumbsDown = endretRating.ThumbsDown;
                await _db.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
