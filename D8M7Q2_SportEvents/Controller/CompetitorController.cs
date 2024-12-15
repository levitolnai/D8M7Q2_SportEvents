using D8M7Q2_SportEvents.Entities.Dto.Competitor;
using D8M7Q2_SportEvents.Logic.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace D8M7Q2_SportEvents.Endpoint.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CompetitorController
    {
        CompetitorLogic logic;

        public CompetitorController(CompetitorLogic logic)
        {
            this.logic = logic;
        }

        [HttpPost]
        public void AddCompetitor(CompetitorCreateDto dto)
        {
            logic.AddCompetitor(dto);
        }
    }
}
