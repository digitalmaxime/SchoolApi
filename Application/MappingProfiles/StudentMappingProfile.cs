using Application.CQRS.Students;
using AutoMapper;
using Domain.Models;

namespace Application.MappingProfiles;

public class StudentMappingProfile : Profile
{
        public StudentMappingProfile() {
            // Add as many of these lines as you need to map your objects
            CreateMap<Student, StudentDto>()
                .ForMember(s => 
                    s.StudentName, opt => opt.MapFrom(src => src.StudentName))
                .ForMember(s => 
                    s.IsAdult, opt => opt.MapFrom( x =>  DateTime.Now.Year - x.DateOfBirth.Value.Year >= 18) );

            CreateMap<StudentDto, Student>()
                .ForMember(dest => 
                    dest.StudentId, opt => opt.MapFrom(src => 1234))
                .ForMember(dest => 
                    dest.StudentName, opt => opt.MapFrom(src => src.StudentName))
                .ForMember(dest => 
                    dest.DateOfBirth, opt => opt.MapFrom(src => "1988-12-04"));
        }
}