using System;
using AutoMapper;
using TodoApi.DTO;
using TodoApi.Models;

namespace TodoApi.AutoMappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BeerInsertDTO, Beer>();
        CreateMap<Beer, BeerDTO>().ForMember(dto => dto.Id, m => m.MapFrom(b => b.BeerId));
        CreateMap<BeerUpdateDTO,Beer>();
    }
}
