using arThek.Entities.Entities;
using arThek.ServiceAbstraction.DTOs;
using AutoMapper;
using System.Linq;

namespace arThek.Services.MapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Mentor, ViewMentorDto>();
            CreateMap<ViewMentorDto, Mentor>();

            CreateMap<Mentor, MentorDto>()
                .ForMember(b => b.BasicMentorShipId, bb => bb.MapFrom(bb => bb.Basic.Id))
                .ForMember(s => s.StandardMentorShipId, ss => ss.MapFrom(ss => ss.Standard.Id))
                .ForMember(p => p.PremiumMentorShipId, pp => pp.MapFrom(pp => pp.Premium.Id))
                .ForMember(a => a.Articles, aa =>
                    aa.MapFrom(ma => ma.MentorArticles.Select(ma => ma.Article.Content).ToList()));

            CreateMap<MentorDto, Mentor>()
                .ForMember(r => r.Resume,
                    rr => rr.Ignore());
        }
    }
}
