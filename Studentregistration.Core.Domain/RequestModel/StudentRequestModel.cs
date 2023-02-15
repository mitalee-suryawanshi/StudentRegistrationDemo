using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentregistration.Core.Domain.RequestModel
{
    public class StudentRequestModel
    {
        public string StudentName { get; set; }

        public string Email { get; set; }

        public DateTime DOB { get; set; }

        public string Address { get; set; }

        public long CourseId { get; set; }       
    }
}
