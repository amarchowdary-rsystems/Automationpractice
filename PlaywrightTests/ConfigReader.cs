using System.IO;
using CsvHelper;
using System.Linq;
using System.Globalization;

public static class ConfigReader
{
    public static (string Username, string Password) GetCredentials()
    {
        using (var reader = new StreamReader("credentials.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<CredentialsData>().ToList();
            var firstRecord = records.First();
            return (firstRecord.Username ?? "", firstRecord.Password ?? "");
        }
    }
}

public class CredentialsData
{
    public string? Username { get; set; }
    public string? Password { get; set; }
}