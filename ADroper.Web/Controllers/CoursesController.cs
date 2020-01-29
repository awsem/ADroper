using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADroper.Core.Models;
using ADroper.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ADroper.Web.Controllers
{

    [Route("api/[controller]")]
    public class CoursesController : Controller
    {
        /// Courses/LAWS/UNDERGRADUATE/2


        [HttpGet("{college}/{degree}/{semester}")]
        public async Task<IActionResult> Get(string college, string degree, int semester)
        {
            if (ValidateParameters(college, degree, semester) == null)
            {
                return NotFound();
            }

            var courses = await Fetcher.GetCoursesAsync(ValidateParameters(college, degree, semester));

            return Ok(courses);
        }


        #region Helpers

        private College ValidateParameters(string college, string degree, int semester)
        {
            if (Colleges.GetCollege(college) == null || Degrees.GetDegree(degree) == null)
                if (semester != 1 || semester != 2 || semester != 3)
                    return null;
            return new College { Name = Colleges.GetCollege(college), Degree = Degrees.GetDegree(degree), Semester = semester, Session = "2017/2018" };
        }

        #endregion
    }
}
