using Entities;
using Newtonsoft.Json;

internal partial class Program
{
    private static async Task Main(string[] args)
    {
        HttpClient client = new HttpClient { BaseAddress = new Uri("https://crm.rdstation.com/api/v1/organizations")};
        var response = await client.GetAsync("?token=6380cd82f52355001af959e1");
        var content = await response.Content.ReadAsStringAsync();
        
        var users = JsonConvert.DeserializeObject<Organization[]>(content);




    }
}