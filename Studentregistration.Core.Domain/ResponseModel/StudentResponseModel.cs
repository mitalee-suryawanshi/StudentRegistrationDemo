using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentregistration.Core.Domain.ResponseModel
{
    public class StudentResponseModel
    {
        public long Id { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }  
        public string Address { get; set; }
        public string CourseName { get; set; }
    }
}
