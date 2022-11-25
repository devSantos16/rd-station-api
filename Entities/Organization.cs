namespace rd_station_api.Entities
{
    public partial class Temperatures
    {
        public partial class Organization
    {
        public string Id { get; set; }
        public string OrganizationId { get; set; }
        public string Name { get; set; }
        public string Resume { get; set; }
        public Uri Url { get; set; }
        public object Address { get; set; }
        public long WonCount { get; set; }
        public long LostCount { get; set; }
        public long OpenedCount { get; set; }
        public long PausedCount { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public List<OrganizationSegment> OrganizationSegments { get; set; }
        public User User { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<object> CustomFields { get; set; }
    }
    }
}