using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Infra.Domain.Entities
{
    public class Course
    {
        public long Id { get; set; }

        public string CourseName { get; set; }

        public Course()
        {
        }
        public Course(int id, string name)
        {
            Id = id;
            CourseName = name;
        }
    }
}
