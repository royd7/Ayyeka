namespace CensusApp.Models
{
    public interface IApplicationSettings
    {
        string CsvFileName { get; set; }
        string SqliteFileName { get; set; }
        string DataInfoFileName { get; set; }

        string DataFolder { get; set; }
    }
}