using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Individuell.Models;

namespace WebApp_Individuell.DAL
{
    public interface IFAQRepository
    {
        Task<List<FAQ>> HentAlle();
        Task<bool> AskQuestion(FAQ innQuestion);
        Task<bool> EndreRating(FAQ endretRating);
    }
}
