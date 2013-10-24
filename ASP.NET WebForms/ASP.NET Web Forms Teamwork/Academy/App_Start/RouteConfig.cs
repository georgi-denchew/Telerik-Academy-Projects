using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace Forum
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(
                "LectureInCourseRoute",
                "Lecturer/Courses/{courseId}",
                "~/Lecturer/Lecture.aspx");

            routes.MapPageRoute(
                "StudentInCourseRoute",
                "Student/Courses/{courseId}",
                "~/Student/Lecture.aspx");

            routes.MapPageRoute(
                "StudentHomeworkRoute",
                "Student/Homeworks/{lectureId}",
                "~/Student/Homework.aspx");

            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
        }
    }
}
