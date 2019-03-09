using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dormouse.Database.Repository;
using Dormouse.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dormouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShareController : ControllerBase
    {
        private readonly DormouseDbContext dbContext;

        public ShareController(DormouseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult List(int periodId)
        {
            var result = dbContext.ShareItems
                        .Include(a => a.VoteItems)
                        .Where(a => a.PeriodId == periodId)
                        .GroupBy(a => a) // groupby的条件是一个类的话好像是内存分组
                        .Select(g => new
                        {
                            ShareItem = g.Key,
                            Count = g.Count()
                        });
            return Ok(result.ToList());
        }
    }
}