using AutoMapper;
using MyAutoMapperSample.Model;

namespace MyAutoMapperSample.Eight;

public class UserLookupUpsertModelTypeConverter : ITypeConverter<UserPropertiesContainer, User>
{
    public User Convert(UserPropertiesContainer source, User destination, ResolutionContext context)
    {
        //empty to demo the bug
        return destination;
    }
}