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
    public class TeamController : ControllerBase
    {
        private readonly DormouseDbContext dbContext;

        public TeamController(DormouseDbContext dbContext)
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
    }
}