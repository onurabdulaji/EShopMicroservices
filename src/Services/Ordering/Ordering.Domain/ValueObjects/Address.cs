namespace Ordering.Domain.ValueObjects
{
    public record Address
    {
        public string FirstName { get;} = default!;
        public string LastName { get;} = default!;
        public string? EmailAdress { get;} = default!;
        public string AdressLine { get;} = default!;
        public string Country { get;} = default!;
        public string State { get;} = default!;
        public string ZipCode { get;} = default!;
    }
}
