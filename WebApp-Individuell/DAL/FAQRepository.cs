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
                List<FAQ> alleFAQs = await _db.FAQs.Select(f => new FAQ
                {
                    Id = f.Id,
                    Question = f.Question,
                    Answer = f.Answer,
                    Category = f.Category,
                    Thumbs = f.Thumbs
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
                var nyFAQRad = new FAQ();
                nyFAQRad.Question = innQuestion.Question;
                nyFAQRad.Category = innQuestion.Category;

                _db.FAQs.Add(nyFAQRad);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
