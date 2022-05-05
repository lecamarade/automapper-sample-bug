using AutoMapper;

var config = new MapperConfiguration(cfg =>
{
    //Combination of these two lines make it fail
    cfg.CreateMap(typeof(Property<>), typeof(Property<>));
    cfg.CreateMap<UserPropertiesContainer, User>().ConvertUsing<MyTypeConverter>();
    
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
});

config.AssertConfigurationIsValid();

var mapper = config.CreateMapper();

var source = new User
{
    UserStoreId = Guid.NewGuid(),
    Nested = new NestedObject()
    {
        AccountId = 1,
        EmployerId = 1
    }
};
try
{
    var dest = mapper.Map<UserPropertiesContainer>(source);//.Dump();
    Console.WriteLine(dest.User.NestedProperty.Value.AccountId);
}
catch(Exception ex)
{
    Console.Error.WriteLine(ex);
}

public class MyTypeConverter : ITypeConverter<UserPropertiesContainer, User>
{
    public User Convert(UserPropertiesContainer source, User destination, ResolutionContext context)
    {
        return destination;
    }
}
public record Property<T>(T Value = default);
public record User
{
    public Guid UserStoreId { get; set; }
    public NestedObject Nested { get; init; }
}

public record UserProperties
{
    public Property<Guid> UserStoreId { get; init; }
    public Property<NestedObject> NestedProperty { get; init; }
}

public record UserPropertiesContainer
{
    public Guid UserStoreId { get; init; }
        
    public UserProperties User { get; init; }
}

public record NestedObjectProperties
{
    public Property<int> AccountId { get; init; }
    public Property<int> EmployerId { get; init; }
}

public record NestedObject
{
    public int AccountId { get; init; }
    public int EmployerId { get; init; }
}