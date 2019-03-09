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
    public class PeriodController : ControllerBase
    {
        private readonly DormouseDbContext dbContext;

        public PeriodController(DormouseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IList<Period>> List(int teamId)
        {
            var result = from period in dbContext.Periods
                         where period.TeamId == teamId
                         select period;
            return result.ToList();
        }
    }
}