using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbLogLayer.Settings
{
    public class DatasoftLogDbSettings : IDatasoftLogDbSettings
    {
        public string HttpExceptionCollectionName { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }

    public interface IDatasoftLogDbSettings
    {
        public string HttpExceptionCollectionName { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
