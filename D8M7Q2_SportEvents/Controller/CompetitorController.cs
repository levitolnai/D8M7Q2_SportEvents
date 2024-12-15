using D8M7Q2_SportEvents.Entities.Dto.Competitor;
using D8M7Q2_SportEvents.Logic.Logic;
using Microsoft.AspNetCore.Mvc;

namespace D8M7Q2_SportEvents.Endpoint.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitorController
    {
        CompetitorLogic logic;

        public CompetitorController(CompetitorLogic logic)
        {
            this.logic = logic;
        }

        [HttpPost]
        public void AddRating(CompetitorCreateDto dto)
        {
            logic.AddCompetitor(dto);
        }
    }
}
