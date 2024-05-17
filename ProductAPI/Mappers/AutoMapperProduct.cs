using AutoMapper;
using ProductAPI.Dto;
using ProductAPI.Models;

namespace ProductAPI.Mappers;

public class AutoMapperProduct 
{
    
    public static Mapper GetEntityToDto()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Product, ResultProductDto>();
        });
        var mapper = new Mapper(config);
        return mapper;
    }
    
    public static Mapper GetDtoToEntity()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<InputProductDto, Product>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        });
        var mapper = new Mapper(config);
        return mapper;
    }
}