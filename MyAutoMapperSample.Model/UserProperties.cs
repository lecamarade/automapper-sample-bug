namespace MyAutoMapperSample.Model
{
    public record UserProperties
    {
        public Property<Guid> UserStoreId { get; init; }
        public Property<NestedObject> NestedProperty { get; init; }
    }
}
