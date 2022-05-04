using AutoMapper;
using MyAutoMapperSample.Model;

namespace MyAutoMapperSample.Eight;

public class MyAutomMapperConfiguration
{
    public static MapperConfiguration GetConfiguration()
    {
        return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap(typeof(Property<>), typeof(Property<>));
                cfg.CreateMap<NestedObject, NestedObjectProperties>()
                    .ForMember(dest => dest.AccountId, opt 
                        => opt.MapFrom(src => new Property<int>(src.AccountId)))
                    .ForMember(dest => dest.EmployerId, opt 
                        => opt.MapFrom(src => new Property<int>(src.EmployerId)));
        
                cfg.CreateMap<User, UserPropertiesContainer>()
                    .ForMember(dest => dest.UserStoreId,
                        opt => opt.MapFrom(src => src.UserStoreId))
                    .ForMember(dest => dest.User, opt
                        => opt.MapFrom(src => src));

                cfg.CreateMap<User, UserProperties>()
                    .ForMember(dest => dest.UserStoreId, 
                        opt => opt.MapFrom(src => new Property<Guid>(src.UserStoreId)))
                    .ForMember(dest => dest.NestedProperty, opt 
                        => opt.MapFrom(src => new Property<NestedObject>(src.Nested)));
            }
        );
    }
}