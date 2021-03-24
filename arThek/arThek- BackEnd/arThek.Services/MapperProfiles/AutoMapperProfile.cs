﻿using arThek.Entities.Entities;
using arThek.ServiceAbstraction.DTOs;
using AutoMapper;

namespace arThek.Services.MapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            /*
             * Mentor
             */
            CreateMap<Mentor, MentorDto>()
                .ForMember(b => b.BasicMentorShipId, bb => bb.MapFrom(bb => bb.Basic.Id))
                .ForMember(s => s.StandardMentorShipId, ss => ss.MapFrom(ss => ss.Standard.Id))
                .ForMember(p => p.PremiumMentorShipId, pp => pp.MapFrom(pp => pp.Premium.Id))
                .ForMember(r => r.Resume,
                    rr => rr.Ignore());

            CreateMap<MentorDto, Mentor>()
                .ForMember(r => r.Resume,
                    rr => rr.Ignore());

            CreateMap<Mentor, BaseUserDto>();
            CreateMap<BaseUserDto, Mentor>();

            CreateMap<CreateUpdateMentorDto, Mentor>();
            CreateMap<Mentor, CreateUpdateMentorDto>();

            CreateMap<Mentor, ViewMentorDto>();
            CreateMap<ViewMentorDto, Mentor>();

            /*
             * Mentee
             */
            CreateMap<Mentee, MenteeDto>();
            CreateMap<MenteeDto, Mentee>()
                .ForMember(i => i.ProfileImage,
                    ii => ii.Ignore());

            CreateMap<Mentee, BaseUserDto>();
            CreateMap<BaseUserDto, Mentee>();

            /*
             * Article
             */
            CreateMap<ArticleDto, Article>();
            CreateMap<Article, ArticleDto>()
                .ForMember(a => a.AuthorId, aa => aa.MapFrom(aa => aa.AuthorId))
                .ForMember(i => i.Image,
                    ii => ii.Ignore());

            CreateMap<Article, ViewArticleDto>();
            CreateMap<ViewArticleDto, Article>();

            /*
             * GuestUser
             */
            CreateMap<BaseUserDto, GuestUser>();
            CreateMap<GuestUser, BaseUserDto>()
                .ForMember(b => b.EmailAddress, gg => gg.MapFrom(gg => gg.Email));
        }
    }
}
