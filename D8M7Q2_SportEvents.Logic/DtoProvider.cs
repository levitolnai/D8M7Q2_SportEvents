using AutoMapper;
using D8M7Q2_SportEvents.Entities;
using D8M7Q2_SportEvents.Entities.Dto.SportEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D8M7Q2_SportEvents.Logic
{
    public class DtoProvider
    {
        public Mapper Mapper { get; }

        public DtoProvider()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SportEvent, SportEventShortViewDto>();
                cfg.CreateMap<SportEvent, SportEventViewDto>();
                cfg.CreateMap<SportEventCreateUpdateDto, SportEvent>();
            });

            Mapper = new Mapper(config);
        }
    }
}
