using D8M7Q2_SportEvents.Data;
using D8M7Q2_SportEvents.Entities;
using D8M7Q2_SportEvents.Entities.Dto.Competitor;
using D8M7Q2_SportEvents.Logic.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D8M7Q2_SportEvents.Logic.Logic
{
    public class CompetitorLogic
    {
        Repository<Competitor> repo;
        DtoProvider dtoProvider;

        public CompetitorLogic(Repository<Competitor> repo, DtoProvider dtoProvider)
        {
            this.repo = repo;
            this.dtoProvider = dtoProvider;
        }

        public void AddCompetitor(CompetitorCreateDto dto, string userId)
        {
            int competitorCount = repo.GetAll().Where(x => x.SportEventId == dto.SportEventId).Count();
            int competitorLimit = repo.GetAll().Where(x => x.SportEventId == dto.SportEventId).Select(x => x.SportEvent.CompetitorLimit).FirstOrDefault();
            var model = dtoProvider.Mapper.Map<Competitor>(dto);
            model.UserId = userId;
            if (competitorCount < competitorLimit)
            {
                repo.Create(model);
            }
            else
            {
                //todo throw exception
            }


        }
    }
}
