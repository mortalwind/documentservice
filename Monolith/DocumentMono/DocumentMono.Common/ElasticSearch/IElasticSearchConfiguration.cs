namespace DocumentMono.Common.ElasticSearch
{
    public interface IElasticSearchConfiguration
    {
        string ConnectionString { get; }
        string Username { get; }
        string Password { get; }
    }
}
