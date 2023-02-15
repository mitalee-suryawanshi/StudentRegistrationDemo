using Microsoft.EntityFrameworkCore;
using StudentRegistration.Infra.Contract;
using StudentRegistration.Infra.Domain;
using StudentRegistration.Infra.Domain.Entities;
using StudentRegistration.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Infra.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentContext _context;
        public StudentRepository(StudentContext studentContext)
        {
            _context = studentContext;
        }

        public async Task<int> AddStudent(Student student)
        {
            await _context.Student.AddAsync(student);
            return await _context.SaveChangesAsync();
        }

        public async Task<PagedList<Student>> GetStudents(string searchTerm = null, int page = 1, int pageSize = 25)
        {
            try
            {
                var result = _context.Student.Include(x => x.Course).Where(x => !x.IsDeleted).OrderByDescending(x => x.CreatedOn).AsQueryable();              
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    result = result.Where(x =>
                        EF.Functions.Like(x.StudentName, $"%{searchTerm}%") ||
                        EF.Functions.Like(x.Email, $"%{searchTerm}%") ||
                        EF.Functions.Like(x.Address, $"%{searchTerm}%") ||
                        EF.Functions.Like(x.Course.CourseName, $"%{searchTerm}%")
                    );
                }

                var count = await result.LongCountAsync();
                var pagedList = result.ToPagedList(page, pageSize, count);
                return pagedList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Student?> GetStudent(long studentId)
        {
            var result = await _context.Student.FirstOrDefaultAsync(x=>x.Id == studentId);
            return result;
        }

        public async Task<int> UpdateStudents(long studentId, Student student)
        {
            try
            {
                var result = _context.Student.Where(x=>x.Id==studentId && !x.IsDeleted).FirstOrDefault();
                result.StudentName = student.StudentName;
                result.Email = student.Email;
                result.DOB=student.DOB;
                result.Address = student.Address;
                result.CourseId= student.CourseId;
                _context.Student.Update(result);
                return await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public Task<int> DeleteStudent(Student student)
        {
            _context.Student.Update(student);
            return _context.SaveChangesAsync();
        }
    }
}