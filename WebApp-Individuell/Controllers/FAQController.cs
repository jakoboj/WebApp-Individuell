using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Individuell.DAL;
using WebApp_Individuell.Models;

namespace WebApp_Individuell.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FAQController : ControllerBase
    {
        private IFAQRepository _db;

        public FAQController(IFAQRepository db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<ActionResult> HentAlle()
        {
            List<FAQ> alleFAQ = await _db.HentAlle();
            return Ok(alleFAQ);
        }
    }
}
