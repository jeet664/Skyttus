using AutoMapper;
using StudentManagementAPI.Models;
using StudentManagementAPI.DTOs;

namespace StudentManagementAPI.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentReadDTO>();
            CreateMap<StudentCreateDTO, Student>();
            CreateMap<StudentUpdateDTO, Student>();
        }
    }
}
