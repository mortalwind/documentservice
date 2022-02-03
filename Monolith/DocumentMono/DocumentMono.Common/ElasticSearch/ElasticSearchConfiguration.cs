using Microsoft.Extensions.Configuration;

namespace DocumentMono.Common.ElasticSearch
{
    public class ElasticSearchConfiguration: IElasticSearchConfiguration
    {

        public IConfiguration Configuration { get; }
        public ElasticSearchConfiguration(IConfiguration _Configuration)
        {
            Configuration = _Configuration;
        }

        public string ConnectionString { get { return Configuration.GetSection("ElasticSearch:ConnectionString:HostUrl").Value; } }

        public string Username { get { return Configuration.GetSection("ElasticSearch:ConnectionString:Username").Value; } }

        public string Password { get { return Configuration.GetSection("ElasticSearch:ConnectionString:Password").Value; } }
    }
}
