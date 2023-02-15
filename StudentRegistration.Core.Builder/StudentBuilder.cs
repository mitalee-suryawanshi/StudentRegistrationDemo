using Studentregistration.Core.Domain.RequestModel;
using StudentRegistration.Infra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Core.Builder
{
    public class StudentBuilder
    {
        public static Student Build(StudentRequestModel model)
        {
            return new Student(model.StudentName,model.Email,model.DOB,model.Address,model.CourseId);
        }
    }
}
