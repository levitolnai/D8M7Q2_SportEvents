﻿using D8M7Q2_SportEvents.Data;
using D8M7Q2_SportEvents.Entities;
using D8M7Q2_SportEvents.Entities.Dto.SportEvent;
using D8M7Q2_SportEvents.Entities.Helpers;
using D8M7Q2_SportEvents.Logic.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        [Authorize]
        public void AddSportEvent(SportEventCreateUpdateDto dto)
        {

            logic.AddSportEvent(dto);

        }

        [HttpGet]
        public IEnumerable<SportEventShortViewDto> GetAllSportEvents()
        {
            return logic.GetAllSportEvents();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public void DeleteSportEvent(string id)
        {
            logic.DeleteSportEvent(id);
        }

        [HttpPut("{id}")]
        [Authorize]
        public void UpdateSportEvent(string id, [FromBody] SportEventCreateUpdateDto dto)
        {
            logic.UpdateSportEvent(id, dto);
        }

        [HttpGet("{id}")]
        [Authorize]
        public SportEventViewDto GetSportEvent(string id)
        {
            return logic.GetSportEvent(id);
        }
    }
}
