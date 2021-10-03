using AutoMapper;
using Humanizer;
using TeleBook.Application.Contracts;
using TeleBook.Domain.Models;

namespace TeleBook.Api
{
    public class TeleBookProfile : Profile
    {
        public TeleBookProfile()
        {
            CreateMap<TeleCreateDto, Tele>();
            CreateMap<TeleUpdateDto, Tele>();
            CreateMap<Tele, TeleDto>()
                .ForMember(x => x.GenderValue, opt => opt.MapFrom(c => c.Gender.Humanize()));

        }

    }
}