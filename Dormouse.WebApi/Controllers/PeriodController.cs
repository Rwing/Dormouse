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

        [HttpGet(nameof(List))]
        public ActionResult<IList<Period>> List(int teamId)
        {
            var result = (from period in dbContext.Periods
                          where period.TeamId == teamId
                          orderby period.CreateDate descending
                          select period).ToList();
            // 查找是否有当前时间的周期
            var now = DateTime.Now;
            if (result.FindIndex(i => i.StartDate < now && i.EndDate > now) <= 0)
            {
                var chineseDayOfWeek = now.DayOfWeek == 0 ? 7 : (int)now.DayOfWeek;
                var startDate = now.AddDays(0 - (chineseDayOfWeek - 1));
                var endDate = startDate.AddDays(14);
                var current = new Period
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    CreateDate = now,
                    TeamId = teamId
                };
                dbContext.Periods.Add(current);
                dbContext.SaveChanges();
                result.Add(current);
            }
            return result.ToList();
        }
    }
}