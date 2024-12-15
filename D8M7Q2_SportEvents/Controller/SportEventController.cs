using D8M7Q2_SportEvents.Data;
using D8M7Q2_SportEvents.Entities;
using Microsoft.AspNetCore.Mvc;
using MovieClub.Data;

namespace D8M7Q2_SportEvents.Endpoint.Controller
{
    public class SportEventCreateDto
    {
        public string Title { get; set; }
        private string Description { get; set; }
        public string Date { get; set; }
        public int CompetitorLimit { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class SportEventController : ControllerBase
    {
        Repository<SportEvent> repo;

        public SportEventController(Repository<SportEvent> repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        public void AddSportEvent(SportEvent sportEvent)
        {
            var s = new SportEvent(sportEvent.Title, sportEvent.Description, sportEvent.Date, sportEvent.CompetitorLimit);
            repo.Create(s);
        }
    }
}
