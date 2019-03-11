using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dormouse.Database.Repository;
using Dormouse.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Dormouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DormouseDbContext dbContext;

        public UserController(DormouseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET api/values
        [HttpGet(nameof(Get))]
        public ActionResult<IList<User>> Get()
        {
            var users = from i in dbContext.Users
                        select i;
            return users.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
