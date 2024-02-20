using AutoMapper;
using LearnHub.Application.Students.Dtos;
using LearnHub.Application.Teachers.Dtos;
using LearnHub.Application.Teachers.Interfaces;
using LearnHub.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Teachers.Services
{
    public class TeacherService(ITeacherRepository teacherRepository, IMapper mapper) : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository = teacherRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<GetTeacherWithAssignment> GetTeacherWithAssignment(string registrationCode)
        {
            var teacher = await _teacherRepository.GetTeacherWithAssignment(registrationCode);
            return _mapper.Map<GetTeacherWithAssignment>(teacher);
        }

        public async Task<GetTeacherWithCourse> GetTeacherWithCourse(string registrationCode)
        {
            var teacher = await _teacherRepository.GetTeacherWithCourse(registrationCode);
            return _mapper.Map<GetTeacherWithCourse>(teacher);
        }

        public async Task<GetTeacherWithQualification> GetTeacherWithQualification(string registrationCode)
        {
            var teacher = await _teacherRepository.GetTeacherWithQualification(registrationCode);
            return _mapper.Map<GetTeacherWithQualification>(teacher);
        }
    }
}
