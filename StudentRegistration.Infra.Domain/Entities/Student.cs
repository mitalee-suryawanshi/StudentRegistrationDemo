using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Infra.Domain.Entities
{
    public class Student : Audit
    {      
        public long  Id { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public long CourseId { get; set; }
        public virtual Course Course { get; set; }
        public Student()
        {
        }
 
        public Student(string name, string email, DateTime dob, string address, long courseId)
        {
            StudentName = name;
            Email = email;
            DOB = dob;
            Address = address;
            CourseId = courseId;
            CreatedOn= DateTime.UtcNow;
            IsDeleted = false;
        }

        public Student Delete()
        {
            IsDeleted = true;
            UpdatedOn = DateTime.UtcNow;
            return this;
        }
    }
}