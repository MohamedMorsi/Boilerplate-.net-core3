using AutoMapper;
using Boilerplate.Dtos.Student;
using Boilerplate.Models;

namespace Boilerplate.Profiles
{
    public class StudentProfile  : Profile
    {
        public StudentProfile()
        {
            // createMap< source , destination >();
            CreateMap<Student,StudentReadDto>();
            CreateMap< StudentCreateDto,Student>();
            CreateMap< StudentUpdateDto,Student>();
        }
    }
}