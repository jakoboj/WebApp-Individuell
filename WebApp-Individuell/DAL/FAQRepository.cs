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
                List<FAQ> alleFAQ = await _db.FAQs.Select(f => new FAQ
                {
                    Id = f.Id,
                    Question = f.Question,
                    Answer = f.Answer,
                    Category = f.Category,
                    Thumbs = f.Thumbs
                }).ToListAsync();
                return alleFAQ;
            }
            catch
            {
                return null;
            }
        }
    }
}
