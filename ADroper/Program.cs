using ADroper.Core.Models;
using ADroper.Core.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ADroper
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var path = @"Tests Files\\ICT.json"; 
            Console.WriteLine("Loading Data...");

            var college = new College() { Name = Colleges.ICT, Degree = Degrees.UNDERGRADUATE, Semester = 2, Session = "2017/2018" };
            var courses = await Fetcher.GetCoursesAsync(college);

            Console.WriteLine("Converting Data...");
            var json = JsonConvert.SerializeObject(courses);

            try
            {
                Console.WriteLine("Writing Data...");
                File.WriteAllText(path, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("Done.");
        }

    }
}
