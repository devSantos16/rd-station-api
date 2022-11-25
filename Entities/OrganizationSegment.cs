namespace rd_station_api.Entities
{
    public partial class Temperatures
    {
        public partial class OrganizationSegment
    {
        public string Id { get; set; }
        public string OrganizationSegmentId { get; set; }
        public string Name { get; set; }
        public object IntegrationId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
    }
}