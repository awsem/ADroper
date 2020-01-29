using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ADroper.Core.Models;
using AngleSharp;

namespace ADroper.Core.Services
{
    public static class Fetcher
    {
        #region Methods

        public static async Task<IEnumerable<Course>> GetCoursesAsync(College college)
        {
            var config = Configuration.Default.WithDefaultLoader();
            var url = $"http://myapps.iium.edu.my/StudentOnline/schedule1.php?kuly={college.Name}&sem={college.Semester}&ctype={college.Degree}&course=&action=view&ses={college.Session}&search=Submit";
            var doc = await BrowsingContext.New(config).OpenAsync(url);
            var courses = new List<Course>();
            var pagesCount = await GetPagesCountAsync(college);
            for (int i = 1; i <= pagesCount; i++)
            {
                var address = $"http://myapps.iium.edu.my/StudentOnline/schedule1.php?kuly={college.Name}&sem={college.Semester}&ctype={college.Degree}&view={50 * i}&course=&action=view&ses={college.Session}&search=Submit";
                var cellSelector = "body > table:nth-child(4) > tbody > tr:nth-child(n+3):not(:last-child)";

                var entities = doc.QuerySelectorAll(cellSelector).Select(
                    entity => new
                    {
                        Code = entity.QuerySelector("body > table:nth-child(4) > tbody > tr:nth-child(n+3) > td:nth-child(1):not(:last-child)").TextContent,
                        Section = entity.QuerySelector("body > table:nth-child(4) > tbody > tr:nth-child(n+3) > td:nth-child(2)").TextContent,
                        Title = entity.QuerySelector("body > table:nth-child(4) > tbody > tr:nth-child(n+3) > td:nth-child(3)").TextContent,
                        Days = entity.QuerySelectorAll("body > table:nth-child(4) > tbody > tr:nth-child(n+3) > td:nth-child(5) > table > tbody> tr > td:nth-child(1)").Select(a => a.TextContent),
                        Times = entity.QuerySelectorAll("body > table:nth-child(4) > tbody > tr:nth-child(n+3) > td:nth-child(5) > table > tbody> tr > td:nth-child(2)").Select(a => a.TextContent),
                        Lecturers = entity.QuerySelectorAll("body > table:nth-child(4) > tbody > tr:nth-child(n+3) > td:nth-child(5) > table > tbody> tr > td:nth-child(4)").Select(a => a.TextContent)
                    });

                var myCourses = entities.Select(entity => new Course
                {
                    Code = entity.Code,
                    Title = entity.Title,
                    Sections = new List<Section>
                    {
                        new Section
                        {
                            Number = int.Parse(entity.Section),
                            Days = entity.Days.ToArray(),
                            Times = entity.Times.ToArray(),
                            Lecturers = entity.Lecturers.ToArray()
                        }
                     }
                });

                courses.AddRange(myCourses);
            }

            MeregeSections(ref courses);
            return courses;
        }

        #endregion

        #region Helper Methods

        private static void MeregeSections(ref List<Course> courses)
        {
            for (int i = 0, j = 0; i < courses.Count; j = 0, i++)
            {
                for (int k = 0; k < courses.Count - i - 1; k++)
                {
                    if (courses[i].Title == courses[i + k + 1].Title && courses[i].Code == courses[i + k + 1].Code)
                    {
                        courses[i].Sections.Add(courses[i + k + 1].Sections[0]);
                        j++;
                    }
                    else
                    {
                        break;
                    }
                }
                courses.RemoveRange(i + 1, j);
            }
        }

        private static async Task<int> GetPagesCountAsync(College college)
        {
            var config = Configuration.Default.WithDefaultLoader();
            var url = $"http://myapps.iium.edu.my/StudentOnline/schedule1.php?kuly={college.Name}&sem={college.Semester}&ctype={college.Degree}&course=&action=view&ses={college.Session}&search=Submit";
            var doc = await BrowsingContext.New(config).OpenAsync(url);
            var selector = $"table:nth-child(4) > tbody > tr:nth-child(1) > td > a:last-child";

            var result = doc.QuerySelector(selector).TextContent;
            var count = string.IsNullOrEmpty(result) || string.IsNullOrWhiteSpace(result) ? 1 : int.Parse(result);

            return count;
        }

        #endregion
    }
}
