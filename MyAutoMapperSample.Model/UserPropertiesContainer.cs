namespace MyAutoMapperSample.Model
{
    public record UserPropertiesContainer
    {
        public Guid UserStoreId { get; init; }
        
        public UserProperties User { get; init; }
    }
}
