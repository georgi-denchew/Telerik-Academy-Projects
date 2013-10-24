using Forum.Migrations;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Forum
{
    public class Global : HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AcademyDbContext, Configuration>());

            var context = new AcademyDbContext();
            context.Lectures.ToList();
            var endedCourses = context.Courses.Where(c=>c.EndDate<DateTime.Now).ToList();
            foreach (var course in endedCourses)
            {
                course.IsClosed = true;
            }

            // Code that runs on application startup
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}