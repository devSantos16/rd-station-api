namespace rd_station_api.Entities
{
    public partial class Temperatures
    {
        public partial class Contact
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public object Notes { get; set; }
        public object Facebook { get; set; }
        public object Linkedin { get; set; }
        public object Skype { get; set; }
        public object Birthday { get; set; }
        public List<Emails> Emails { get; set; }
        public List<Phones> Phones { get; set; }
    }
    }
}