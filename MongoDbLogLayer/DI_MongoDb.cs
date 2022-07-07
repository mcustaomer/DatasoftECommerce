using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDbLogLayer.Services;
using MongoDbLogLayer.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbLogLayer
{
    public static class DI_MongoDb
    {
        public static IServiceCollection AddMongoDbDependencies(this IServiceCollection services)
        {
            services.AddSingleton<HttpExceptionLogService>();
            services.AddSingleton<IDatasoftLogDbSettings>(sp => sp.GetRequiredService<IOptions<DatasoftLogDbSettings>>().Value);
            return services;
        }
    }
}
