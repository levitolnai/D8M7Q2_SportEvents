using D8M7Q2_SportEvents.Data;
using D8M7Q2_SportEvents.Entities;
using D8M7Q2_SportEvents.Entities.Dto.SportEvent;
using D8M7Q2_SportEvents.Logic;
using Microsoft.AspNetCore.Mvc;
using MovieClub.Data;

namespace D8M7Q2_SportEvents.Endpoint.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportEventController : ControllerBase
    {
        SportEventLogic logic;

        public SportEventController(SportEventLogic logic)
        {
            this.logic = logic;
        }

        [HttpPost]
        public void AddSportEvent(SportEventCreateDto dto)
        {
            logic.AddSportEvent(dto);
        }

        [HttpGet]
        public IEnumerable<SportEventShortViewDto> GetAllSportEvents()
        {
            return logic.GetAllSportEvents();
        }
    }
}
