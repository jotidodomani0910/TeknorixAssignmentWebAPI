using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JobsOpening.Domain.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }

        public string JobCode { get; private set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime PostedDate { get; set; }
        [Required]
        public DateTime ClosingDate { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public int LocationId { get; set; }
        public virtual Location Location { get; set; }




    }
}
