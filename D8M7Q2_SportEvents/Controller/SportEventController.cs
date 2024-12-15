using D8M7Q2_SportEvents.Data;
using D8M7Q2_SportEvents.Entities;
using Microsoft.AspNetCore.Mvc;

namespace D8M7Q2_SportEvents.Endpoint.Controller
{
    public class SportEventController
    {
        [Route("api/[controller]")]
        [ApiController]
        public class MovieController : ControllerBase
        {
            SportEventContext ctx;

            public MovieController(SportEventContext ctx)
            {
                this.ctx = ctx;
            }

            [HttpPost]
            public void AddMovie(SportEvent sportEvent)
            {
                ctx.SportEvents.Add(sportEvent);
                ctx.SaveChanges();
            }
        }
    }
}
