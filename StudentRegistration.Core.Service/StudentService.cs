using AutoMapper;
using Studentregistration.Core.Domain.Exceptions;
using Studentregistration.Core.Domain.RequestModel;
using Studentregistration.Core.Domain.ResponseModel;
using StudentRegistration.Core.Builder;
using StudentRegistration.Core.Contract;
using StudentRegistration.Infra.Contract;
using StudentRegistration.Infra.Domain.Entities;
using StudentRegistration.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Core.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public StudentService(IStudentRepository studentRepository,IMapper mapper)
        {
           _studentRepository=studentRepository;
           _mapper=mapper;
        }
        public async Task<int> AddStudentAsync(StudentRequestModel studentRequestModel)
        {
            try
            {
                var student = StudentBuilder.Build(studentRequestModel);
                var count = await _studentRepository.AddStudent(student);
                if (count == 0)
                {
                    throw new BadRequestException("Student is not created succssfully.");
                }
                return count;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<PagedList<StudentResponseModel>> GetStudentAsync(string searchTerm = null, int page = 1, int pageSize = 25)
        {
            try
            {
                var student = await _studentRepository.GetStudents(searchTerm, page, pageSize);
                var result = _mapper.Map<PagedList<StudentResponseModel>>(student);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<int> DeleteStudentAsync(long studentId)
        {
         try
            {
                var result = await _studentRepository.GetStudent(studentId);
                if (result == null)
                {
                    throw new NotFoundException($"Student with {studentId} is not found.");
                }
                result.Delete();
                var count = await _studentRepository.DeleteStudent(result);
                if(count == 0)
                {
                    throw new BadRequestException("Student is not updated succssfully.");
                }
                return count;
            }
            catch(Exception)
            {
                throw;
            }
        }
        public async Task<int> UpadateStudentAsync(StudentRequestModel student, long studentId)
        {
            var result = StudentBuilder.Build(student);
           return await _studentRepository.UpdateStudents(studentId, result);
        }
    }
}