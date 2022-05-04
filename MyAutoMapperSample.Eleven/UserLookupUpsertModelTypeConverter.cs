using AutoMapper;
using MyAutoMapperSample.Model;

namespace MyAutoMapperSample.Eleven;

public class UserLookupUpsertModelTypeConverter : ITypeConverter<UserPropertiesContainer, User>
{
    public User Convert(UserPropertiesContainer source, User destination, ResolutionContext context)
    {
        //empty to demo the bug
        return destination;
    }
}