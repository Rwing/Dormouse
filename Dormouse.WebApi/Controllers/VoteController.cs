using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dormouse.Database.Repository;
using Dormouse.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dormouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly DormouseDbContext dbContext;

        public VoteController(DormouseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet(nameof(List))]
        public ActionResult<IList<Team>> List()
        {
            var result = from i in dbContext.Teams
                        select i;
            return result.ToList();
        }

        [HttpPost(nameof(Up))]
        public async Task<ActionResult<VoteItem>> Up([FromBody] VoteItem voteItem)
        {
            // TODO get current user
            voteItem.CreateDate = DateTime.Now;
            dbContext.VoteItems.Add(voteItem);
            await dbContext.SaveChangesAsync();
            return voteItem;
        }
    }
}