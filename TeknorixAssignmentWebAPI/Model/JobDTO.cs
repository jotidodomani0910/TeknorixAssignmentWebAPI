using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobOpeningsAPI.Model
{
    public class JobDTO
    {

        public string Title { get; set; }

        public string Description { get; set; }

        public int LocationId { get; set; }

        public int DepartmentId { get; set; }

        public DateTime ClosingDate { get; set; }

    }
}
