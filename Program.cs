using System.Diagnostics;
using ClosedXML.Excel;
using Newtonsoft.Json;
using rd_station_api.Entities;

internal partial class Program
{
    private static async Task Main(string[] args)
    {
        string path = @"c:\temp\program.xlsx";
        File.Delete(path);

        HttpClient client = new HttpClient { BaseAddress = new Uri("https://crm.rdstation.com/api/v1/organizations") };
        var response = await client.GetAsync("?token=6380cd82f52355001af959e1");
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<Temperatures>(content);
        var enterprise = result.Organizations;
        List<dynamic> informations = new List<dynamic>();


        for (int i = 0; i < enterprise.Count; i++)
        {
            List<dynamic> contacts = new List<dynamic>();

            string id = enterprise[i].Id;
            string name = enterprise[i].Name;
            string url = Convert.ToString(enterprise[i].Url);
            string resume = Convert.ToString(enterprise[i].Resume);

            foreach (var item in enterprise[i].Contacts)
            {
                List<string> phone = new List<string>();
                List<string> email = new List<string>();

                string contacts_name = item.Name;
                string contacts_title = item.Title;

                foreach (var itemPhone in item.Phones)
                {
                    phone.Add(itemPhone.Phone);
                }

                foreach (var itemEmail in item.Emails)
                {
                    email.Add(itemEmail.Email);
                }

                contacts.Add(new { contacts_name, contacts_title, phone, email });
            }

            informations.Add(new { id, name, url, resume, contacts });
        }

        using (var workbook = new XLWorkbook())
        {

            string a, b, c, d, e;

            var main_sheet = workbook.Worksheets.Add("Organizações");
            var contacts_sheet = workbook.Worksheets.Add("Contatos");

            main_sheet.Cell("A1").Value = "ID";
            main_sheet.Cell("B1").Value = "Name";
            main_sheet.Cell("C1").Value = "URL";
            main_sheet.Cell("D1").Value = "Resume";

            contacts_sheet.Cell("A1").Value = "Name";
            contacts_sheet.Cell("B1").Value = "Title";
            contacts_sheet.Cell("C1").Value = "Phone";
            contacts_sheet.Cell("D1").Value = "Email";

            for (int i = 0; i < informations.Count; i++)
            {

                a = $"A{i + 2}";
                b = $"B{i + 2}";
                c = $"C{i + 2}";
                d = $"D{i + 2}";
                e = $"E{i + 2}";

                main_sheet.Cell(a).Value = informations[i].id;
                main_sheet.Cell(b).Value = informations[i].name;
                main_sheet.Cell(c).Value = informations[i].url;
                main_sheet.Cell(d).Value = informations[i].resume;

                foreach (var item in informations[i].contacts)
                {
                    string phones = "";
                    string emails = "";
                    
                    contacts_sheet.Cell(a).Value = item.contacts_name;
                    contacts_sheet.Cell(b).Value = item.contacts_title;


                    foreach (var itemPhone in item.phone)
                    {
                        phones += $" [{itemPhone}] ";
                    }

                    contacts_sheet.Cell(c).Value = phones;

                    foreach (var itemEmail in item.email)
                    {
                        emails += $" [{itemEmail}] ";
                    }

                    contacts_sheet.Cell(d).Value = emails;

                }

            }

            workbook.SaveAs(path);
            Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });

        }
    }
}