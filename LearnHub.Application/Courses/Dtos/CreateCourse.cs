using LearnHub.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Courses.Dtos
{
    public class CreateCourse
    {
        public string? CourseName { get; set; }
        public int Period { get; set; }
        public int Year { get; set; }
    }
}
