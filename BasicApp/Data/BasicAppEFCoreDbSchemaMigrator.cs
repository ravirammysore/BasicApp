using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace BasicApp.Data;

public class BasicAppEFCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public BasicAppEFCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the BasicAppDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<BasicAppDbContext>()
            .Database
            .MigrateAsync();
    }
}
