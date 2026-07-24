using AutoMapper;
using EduTrack.Api.Models.DTOs.Student;
using EduTrack.Api.Models.Entities;

namespace EduTrack.Api.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Student, StudentDto>();

        CreateMap<CreateStudentDto, Student>();

        CreateMap<UpdateStudentDto, Student>();

        CreateMap<Student, UpdateStudentDto>();
    }
}