using JobsOpening.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobOpeningsAPI.Model
{
    public class AllJobDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Code { get; set; }

        public DateTime PostedDate { get; set; }
        public DateTime ClosingDate { get; set; }

        public virtual Department Department { get; set; }
        public virtual Location Location { get; set; }
    }
}
