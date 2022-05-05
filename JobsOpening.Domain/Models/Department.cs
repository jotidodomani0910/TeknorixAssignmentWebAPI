﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JobsOpening.Domain.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
