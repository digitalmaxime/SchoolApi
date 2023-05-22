using Application.CQRS.StudentsDto;
using AutoMapper;
using Domain.Models;
using Application.CQRS.Dtos;
namespace Application.MappingProfiles;

public class StudentMappingProfile : Profile
{
        public StudentMappingProfile() {
            // Add as many of these lines as you need to map your objects
            CreateMap<Student, StudentDto>()
                .ForMember(dest => 
                    dest.StudentName, opt => opt.MapFrom(src => src.StudentName))
                .ForMember(dest => 
                    dest.IsAdult, opt => opt.MapFrom( x =>  DateTime.Now.Year - x.DateOfBirth.Value.Year >= 18) )
                .ForMember(dest => 
                dest.Location, opt => opt.MapFrom( x => new StudentCityStateDto() { City = x.StudentAddress.City, State = x.StudentAddress.State }));

            CreateMap<StudentDto, Student>()
                .ForMember(dest => 
                    dest.StudentId, opt => opt.MapFrom(src => 1234))
                .ForMember(dest => 
                    dest.StudentName, opt => opt.MapFrom(src => src.StudentName))
                .ForMember(dest => 
                    dest.DateOfBirth, opt => opt.MapFrom(src => "1988-12-04"));
        }
}