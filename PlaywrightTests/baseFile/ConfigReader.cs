using System.IO;
using CsvHelper;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;

public static class ConfigReader
{
    public static (string Username, string Password) GetCredentials()
    {
        using (var reader = new StreamReader("C:\\Users\\thb\\Downloads\\Automation\\Automationpractice\\PlaywrightTests\\testData\\credentials.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<CredentialsData>().ToList();
            var firstRecord = records.First();
            return (firstRecord.Username ?? "", firstRecord.Password ?? "");
        }
    }
    public static TeamMemberData GetTeamMemberData()
    {
        using (var reader = new StreamReader("C:\\Users\\thb\\Downloads\\Automation\\Automationpractice\\PlaywrightTests\\testData\\AddTeamMemberData.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<TeamMemberData>().ToList();
            return records.FirstOrDefault(); 
        }
    }

    public static List<TeamMemberData> GetAllTeamMemberData()
    {
        using (var reader = new StreamReader("C:\\Users\\thb\\Downloads\\Automation\\Automationpractice\\PlaywrightTests\\testData\\AddTeamMemberData.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            return csv.GetRecords<TeamMemberData>().ToList(); 
        }
    }

    public static (string RoleValue, string TeacherTypeValue) GetDropdownValues()
    {
        using (var reader = new StreamReader("C:\\Users\\thb\\Downloads\\Automation\\Automationpractice\\PlaywrightTests\\testData\\dropdownValues.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<DropdownValuesData>().ToList();
            var firstRecord = records.First();
            return (firstRecord.RoleValue ?? "", firstRecord.TeacherTypeValue ?? "");
        }
    }
}

public class CredentialsData
{
    public string? Username { get; set; }
    public string? Password { get; set; }
}

public class TeamMemberData
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? ConfirmPassword { get; set; }
    public string? RoleValue { get; set; }
    public string? TeacherTypeValue { get; set; }
    public string? ExpectedResult { get; set; } // New column added
}

public class DropdownValuesData
{
    public string? RoleValue { get; set; }
    public string? TeacherTypeValue { get; set; }
}
