using Studentregistration.Core.Domain.RequestModel;
using Studentregistration.Core.Domain.ResponseModel;
using StudentRegistration.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Core.Contract
{
    public interface IStudentService
    {
        Task<int> AddStudentAsync(StudentRequestModel student);

        /// <summary>
        /// Get Candidate based on search term
        /// </summary>
        /// <param name="searchTerm">searchTerm</param>
        /// <param name="page">page = 1</param>
        /// <param name="pageSize">pageSize = 25</param>
        /// <returns></returns>

        Task<PagedList<StudentResponseModel>> GetStudentAsync(string searchTerm = null, int page = 1, int pageSize= 25);
        Task<int> UpadateStudentAsync(StudentRequestModel student,long studentId);
        Task<int> DeleteStudentAsync(long studentId);
    }
}
