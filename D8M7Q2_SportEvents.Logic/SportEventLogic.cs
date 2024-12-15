using D8M7Q2_SportEvents.Entities;
using D8M7Q2_SportEvents.Entities.Dto.SportEvent;
using MovieClub.Data;

namespace D8M7Q2_SportEvents.Logic
{
    public class SportEventLogic
    {
        Repository<SportEvent> repo;

        public SportEventLogic(Repository<SportEvent> repo)
        {
            this.repo = repo;
        }

        public void AddSportEvent(SportEventCreateDto dto)
        {
            SportEvent s = new SportEvent(dto.Title, dto.Description, dto.Date, dto.CompetitorLimit);
            repo.Create(s);
        }
    }
}
