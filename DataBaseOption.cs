namespace MyFirstApi;

public class DataBaseOption
{
    public const string SectionName = "DatabaseOneConf";
    
    public const string SectionNameMultipleConf = "Database";
    public const string SystemDatabaseSectionName = "System";
    public const string BusinessDatabaseSectionName = "Business";
    public string Type { get; set; } = string.Empty;
    public string ConnectionString { get; set; } = string.Empty;
}