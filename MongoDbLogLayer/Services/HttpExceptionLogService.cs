using MongoDB.Driver;
using MongoDbLogLayer.LogEntities;
using MongoDbLogLayer.Settings;
using System.Collections.Generic;
using System.Linq;

namespace MongoDbLogLayer.Services
{
    public class HttpExceptionLogService
    {
        private readonly IMongoCollection<HttpExceptionLog> _httpExceptionLogs;

        public HttpExceptionLogService(IDatasoftLogDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _httpExceptionLogs = database.GetCollection<HttpExceptionLog>(settings.HttpExceptionCollectionName);
        }

        public List<HttpExceptionLog> Get()
        {
            var httpExceptionLogs = _httpExceptionLogs.Find(logs => true).ToList();
            return httpExceptionLogs;
        }

        public HttpExceptionLog Get(string id) => _httpExceptionLogs.Find<HttpExceptionLog>(logs => logs.Id == id).FirstOrDefault();

        public void Insert(HttpExceptionLog log) => _httpExceptionLogs.InsertOne(log);
    }
}
