using AutoMapper;
using LearnHub.Application.Students.Dtos;
using LearnHub.Application.Students.Interfaces;
using LearnHub.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Students.Services
{
    public class StudentService(IStudentRepository studentRepository, IMapper mapper) : IStudentService
    {
        private readonly IStudentRepository _studentRepository = studentRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<GetStudentWithAssignment> GetStudentWithAssignment(string registrationCode)
        {
            var student = await _studentRepository.GetStudentWithAssignment(registrationCode);
            return _mapper.Map<GetStudentWithAssignment>(student);
        }

        public async Task<GetStudentWithQualification> GetStudentWithQualification(string registrationCode)
        {
            var student = await _studentRepository.GetStudentWithQualification(registrationCode);
            return _mapper.Map<GetStudentWithQualification>(student);
        }

        public async Task<GetStudentWithCourse?> GetStudentWithCourse(string registrationCode)
        {
            var student = await _studentRepository.GetStudentWithCourse(registrationCode);
            return _mapper.Map<GetStudentWithCourse>(student);
        }
    }
}
