using AutoMapper;
using Studentregistration.Core.Domain.ResponseModel;
using StudentRegistration.Infra.Domain.Entities;
using StudentRegistration.Shared;

namespace StudentRegistrationDemo.API.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, StudentResponseModel>()
            .ForMember(x => x.CourseName, opt => opt.MapFrom(c => c.Course.CourseName));
            // student is Source and StudentResponseModel is Destination
            CreateMap<PagedList<Student>, PagedList<StudentResponseModel>>();
        }      
    }
}