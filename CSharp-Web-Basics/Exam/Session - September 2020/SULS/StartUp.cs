using Microsoft.EntityFrameworkCore;
using SULS.Data;
using SULS.Services;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Collections.Generic;

namespace SULS.App
{

    public class StartUp : IMvcApplication
    {
        public void Configure(IList<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IProblemsService, ProblemsService>();
            serviceCollection.Add<ISubmissionsService, SubmissionsService>();
        }
    }
}