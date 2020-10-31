using Microsoft.EntityFrameworkCore;
using MUSACA.Data;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Collections.Generic;

namespace MUSACA
{
    class Startup : IMvcApplication
    {
        public void Configure(IList<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();            
        }
    }
}
