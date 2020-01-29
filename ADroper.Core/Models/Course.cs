using System.Collections.Generic;

namespace ADroper.Core.Models
{
    public class Course
    {
        public string Title { get; set; }

        public string Code { get; set; }

        public IList<Section> Sections { get; set; }

    }

}
