
namespace Catalog.API.Settings
{
    public interface ICatelogDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string CollectionName { get; set; }
    }
}
