namespace MyAutoMapperSample.Model
{
    public record User
    {
        public Guid UserStoreId { get; set; }
        public NestedObject Nested { get; init; }
    }
}
