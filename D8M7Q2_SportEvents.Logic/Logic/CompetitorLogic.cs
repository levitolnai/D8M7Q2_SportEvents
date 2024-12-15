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

        public void AddCompetitor(CompetitorCreateDto dto)
        {
            var model = dtoProvider.Mapper.Map<Competitor>(dto);
            repo.Create(model);
        }
    }
}
