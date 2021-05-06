using arThek.Entities.Entities;
using arThek.ServiceAbstraction.DTOs;
using AutoMapper;

namespace arThek.Services.MapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Mentor Configuration
            CreateMap<CreateMentorDto, Mentor>()
            .ForMember(r => r.Resume,
                    rr => rr.Ignore())
            .ForMember(r => r.ProfileImagePath,
                    rr => rr.Ignore());

            CreateMap<Mentor, MentorDto>()
                .ForMember(b => b.BasicMentorShipId, bb => bb.MapFrom(bb => bb.Basic.Id))
                .ForMember(s => s.StandardMentorShipId, ss => ss.MapFrom(ss => ss.Standard.Id))
                .ForMember(p => p.PremiumMentorShipId, pp => pp.MapFrom(pp => pp.Premium.Id));

            CreateMap<MentorDto, Mentor>()
                .ForMember(r => r.Resume,
                    rr => rr.Ignore())
            .ForMember(r => r.ProfileImagePath,
                    rr => rr.Ignore());

            CreateMap<MentorProfileUpdateDto, Mentor>()
                .ForMember(r => r.Resume,
                    rr => rr.Ignore())
            .ForMember(r => r.ProfileImagePath,
                    rr => rr.Ignore());

            CreateMap<Mentor, MentorProfileUpdateDto>()
                .ForMember(b => b.BasicMentorShipId, bb => bb.MapFrom(bb => bb.Basic.Id))
                .ForMember(s => s.StandardMentorShipId, ss => ss.MapFrom(ss => ss.Standard.Id))
                .ForMember(p => p.PremiumMentorShipId, pp => pp.MapFrom(pp => pp.Premium.Id));

            CreateMap<MentorAdditionalDataDto, Mentor>()
                .ForMember(r => r.Resume,
                    rr => rr.Ignore())
            .ForMember(r => r.ProfileImagePath,
                    rr => rr.Ignore())
            .ForMember(rn => rn.ResumeFileName,
                rndto => rndto.MapFrom(rndto => rndto.Resume.FileName));

            CreateMap<Mentor, MentorAdditionalDataDto>()
                .ForMember(r => r.Resume,
                    rr => rr.Ignore());

            CreateMap<Mentor, BaseUserDto>();
            CreateMap<BaseUserDto, Mentor>();

            CreateMap<CreateUpdateMentorDto, Mentor>();
            CreateMap<Mentor, CreateUpdateMentorDto>();

            CreateMap<Mentor, ViewMentorDto>();
            CreateMap<ViewMentorDto, Mentor>();
            #endregion

            #region Mentee Configuration
            CreateMap<Mentee, MenteeDto>();
            CreateMap<MenteeDto, Mentee>();

            CreateMap<Mentee, BaseUserDto>();
            CreateMap<BaseUserDto, Mentee>();
            #endregion

            #region CreateMenteeDto

            CreateMap<CreateMenteeDto, Mentee>()
                .ForMember(r => r.ProfileImagePath,
                rr => rr.Ignore());

            #endregion

            #region Article Configuration
            CreateMap<ArticleDto, Article>();
            CreateMap<Article, ArticleDto>()
                .ForMember(a => a.AuthorId, aa => aa.MapFrom(aa => aa.AuthorId))
                .ForMember(i => i.Image,
                    ii => ii.Ignore());

            CreateMap<Article, ViewArticleDto>();
            CreateMap<ViewArticleDto, Article>();
            #endregion

            #region GuestUser Configuration
            CreateMap<BaseUserDto, GuestUser>();
            CreateMap<GuestUser, BaseUserDto>()
                .ForMember(b => b.EmailAddress, gg => gg.MapFrom(gg => gg.Email));
            #endregion

            #region ChatMessage Configuration
            CreateMap<ChatMessage, ChatMessageDto>();
            CreateMap<ChatMessageDto, ChatMessage>();
            #endregion
        }
    }
}
