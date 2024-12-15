using AutoMapper;
using D8M7Q2_SportEvents.Entities;
using D8M7Q2_SportEvents.Entities.Dto.Competitor;
using D8M7Q2_SportEvents.Entities.Dto.SportEvent;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D8M7Q2_SportEvents.Logic.Helpers
{
    public class DtoProvider
    {
        UserManager<IdentityUser> userManager;
        public Mapper Mapper { get; }

        public DtoProvider(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SportEvent, SportEventShortViewDto>();
                //.AfterMap((src, dest) =>
                //{
                //    dest.CompetitorCount = src.Competitors?.Count ?? 0;
                //});
                cfg.CreateMap<SportEvent, SportEventViewDto>();
                cfg.CreateMap<SportEventCreateUpdateDto, SportEvent>();
                cfg.CreateMap<CompetitorCreateDto, Competitor>();
                cfg.CreateMap<Competitor, CompetitorViewDto>()
                .AfterMap((src, dest) =>
                {
                    dest.UserFullName = userManager.Users.First(u => u.Id == src.UserId).UserName!;
                });
            });

            Mapper = new Mapper(config);
        }
    }
}
