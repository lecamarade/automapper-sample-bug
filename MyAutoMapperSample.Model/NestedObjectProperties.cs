namespace MyAutoMapperSample.Model
{
    public record NestedObjectProperties
    {
        public Property<int> AccountId { get; init; }
        public Property<int> EmployerId { get; init; }
    }
}
