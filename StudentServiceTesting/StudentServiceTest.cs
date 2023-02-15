using AutoMapper;
using Moq;
using Studentregistration.Core.Domain.Exceptions;
using Studentregistration.Core.Domain.RequestModel;
using StudentRegistration.Core.Service;
using StudentRegistration.Infra.Contract;
using StudentRegistration.Infra.Domain.Entities;
using StudentRegistration.Shared;
using StudentRegistrationDemo.API.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace StudentServiceTesting
{
    public class StudentServiceTest
    {
        private readonly StudentService _studentService;
        private readonly Mock<IStudentRepository> _studentRepositoryMock;
        private readonly IMapper mapper;
        private readonly MapperConfiguration _configuration;
        public StudentServiceTest()
        {
            _studentRepositoryMock = new Mock<IStudentRepository>();
            _configuration = new MapperConfiguration(c => c.AddProfile<AutoMapperProfile>());
            mapper = _configuration.CreateMapper();
            _studentService = new StudentService(_studentRepositoryMock.Object, mapper);
        }

        [Fact]
        public async Task AddStudent_Test()
        {
            StudentRequestModel request = new StudentRequestModel()
            {
                StudentName = "Mitalee",
                Email = "mitalee@gmail.com",
                DOB = DateTime.Now,
                Address = "Surat"
            };
            _studentRepositoryMock.Setup(AS => AS.AddStudent(It.IsAny<Student>())).ReturnsAsync(1);
            var result = await _studentService.AddStudentAsync(request);
            Assert.Equal(1, result);
        }

        [Fact]
        public async Task AddStudent_CheckCondition()
        {
            StudentRequestModel requestModel = new StudentRequestModel()
            {
                StudentName = "Mitalee",
                Email = "mitalee@gmail.com",
                DOB = DateTime.Now,
                Address = "Surat"
            };
            _studentRepositoryMock.Setup(AS => AS.AddStudent(It.IsAny<Student>())).ReturnsAsync(0);
            var result = _studentService.AddStudentAsync(requestModel);
            await Assert.ThrowsAsync<BadRequestException>(async () => await result);
        }

        [Fact]
        public async Task Student_Must_Pass_Test()
        {
            List<Student> GetStudentData = new List<Student>
            {
                new Student() 
                {
                     StudentName = "Mitalee",
                    Email = "mitalee@gmail.com",
                    DOB = DateTime.Now,
                    Address = "Surat"
                }
            };

            PagedList<Student> request = new PagedList<Student>()
            {
                Items = GetStudentData,
                CurrentPage = 1,
                TotalPage = 20,
                PageSize = 1,
                TotalCount = 1
            };
            _studentRepositoryMock.Setup(GS => GS.GetStudents(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(request);
            var result=await _studentService.GetStudentAsync("m", 1, 1);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task DeleteStudent_Test()
        {
            Student request = new Student()
            { 
                StudentName="Mitalee",
                Email= "mitalee@gmail.com",
                DOB=DateTime.Now,
                Address="Surat"
            };
            _studentRepositoryMock.Setup(GS => GS.GetStudent(It.IsAny<long>())).ReturnsAsync(request);
            _studentRepositoryMock.Setup(DS => DS.DeleteStudent(It.IsAny<Student>())).ReturnsAsync(1);
            var result=await _studentService.DeleteStudentAsync(1);
             Assert.Equal(1, result);
        }
        [Fact]
        public async Task DeleteStudent_CheckCondition()
        {
            Student request = new Student() 
            {
                StudentName = "Mitalee",
                Email = "mitalee@gmail.com",
                DOB = DateTime.Now,
                Address = "Surat",
                CourseId=1
            };
            _studentRepositoryMock.Setup(S => S.GetStudent(It.IsAny<long>())).ReturnsAsync(request);
            _studentRepositoryMock.Setup(D => D.DeleteStudent(It.IsAny<Student>())).ReturnsAsync(0);
           var result =  _studentService.DeleteStudentAsync(1);
            await Assert.ThrowsAsync<BadRequestException>(async () => await result);
        }

        [Fact]
        public async Task UpdateStudent_Test()
        {
            StudentRequestModel request = new StudentRequestModel()
            {
                StudentName = "Mitalee",
                Email = "mitalee@gmail.com",
                DOB = DateTime.Now,
                Address = "Surat"
            };
            _studentRepositoryMock.Setup(US => US.UpdateStudents(It.IsAny<int>(), It.IsAny<Student>())).ReturnsAsync(1);
            var result=await _studentService.UpadateStudentAsync(request, 1);
            Assert.NotNull(result);
        }
    }
}
