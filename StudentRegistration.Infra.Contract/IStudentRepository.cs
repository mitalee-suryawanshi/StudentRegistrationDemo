using StudentRegistration.Infra.Domain.Entities;
using StudentRegistration.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Infra.Contract
{
    public interface IStudentRepository
    {
        Task<int> AddStudent(Student student);

        Task<PagedList<Student>> GetStudents(string searchTerm = null, int page = 1, int pageSize = 25);

        Task<Student> GetStudent(long studentId);

        Task<int> UpdateStudents(long studentId,Student student);

        Task<int> DeleteStudent(Student student);
    }
}
