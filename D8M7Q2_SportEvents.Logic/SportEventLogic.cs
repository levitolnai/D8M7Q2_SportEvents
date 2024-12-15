using D8M7Q2_SportEvents.Entities;
using D8M7Q2_SportEvents.Entities.Dto.SportEvent;
using MovieClub.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace D8M7Q2_SportEvents.Logic
{
    public class SportEventLogic
    {
        Repository<SportEvent> repo;

        public SportEventLogic(Repository<SportEvent> repo)
        {
            this.repo = repo;
        }

        public void AddSportEvent(SportEventCreateUpdateDto dto)
        {
            SportEvent s = new SportEvent(dto.Title, dto.Description, dto.Date, dto.Location, dto.CompetitorLimit);
            if (repo.GetAll().FirstOrDefault(x => x.Title == s.Title) == null)
            {
                repo.Create(s);
            }
            else
            {
                //todo throw exception
            }
        }
        public IEnumerable<SportEventShortViewDto> GetAllSportEvents()
        {
            return repo.GetAll().Select(x =>
                new SportEventShortViewDto()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Date = x.Date,
                    Location = x.Location,
                    CompetitorLimit = x.CompetitorLimit
                }
            );
        }
        public void DeleteSportEvent(string id)
        {
            repo.DeleteById(id);
        }
        public void UpdateSportEvent(string id, SportEventCreateUpdateDto dto)
        {
            var old = repo.FindById(id);
            old.Title = dto.Title;
            old.Description = dto.Description;
            old.Date = dto.Date;
            old.Location = dto.Location;
            old.CompetitorLimit = dto.CompetitorLimit;
            repo.Update(old);
        }
        public SportEventViewDto GetSportEvent(string id)
        {
            var model = repo.FindById(id);
            return new SportEventViewDto()
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Date = model.Date,
                Location = model.Location,
                CompetitorLimit = model.CompetitorLimit,
                Competitors = model.Competitors
            };
        }
    }
}
