using D8M7Q2_SportEvents.Entities;
using D8M7Q2_SportEvents.Entities.Dto.SportEvent;
using D8M7Q2_SportEvents.Logic.Helpers;
using MovieClub.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace D8M7Q2_SportEvents.Logic.Logic
{
    public class SportEventLogic
    {
        Repository<SportEvent> repo;
        DtoProvider dtoProvider;

        public SportEventLogic(Repository<SportEvent> repo, DtoProvider dtoProvider)
        {
            this.repo = repo;
            this.dtoProvider = dtoProvider;
        }

        public void AddSportEvent(SportEventCreateUpdateDto dto)
        {
            SportEvent s = dtoProvider.Mapper.Map<SportEvent>(dto);
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
                dtoProvider.Mapper.Map<SportEventShortViewDto>(x)
            );
        }
        public void DeleteSportEvent(string id)
        {
            repo.DeleteById(id);
        }
        public void UpdateSportEvent(string id, SportEventCreateUpdateDto dto)
        {
            var old = repo.FindById(id);
            dtoProvider.Mapper.Map(dto, old);
            repo.Update(old);
        }
        public SportEventViewDto GetSportEvent(string id)
        {
            var model = repo.FindById(id);
            return dtoProvider.Mapper.Map<SportEventViewDto>(model);
        }
    }
}
