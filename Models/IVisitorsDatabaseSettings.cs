namespace VisitorsNationality.Models
{
    public interface IVisitorsDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string CollectionName { get; set; }
    }
}
