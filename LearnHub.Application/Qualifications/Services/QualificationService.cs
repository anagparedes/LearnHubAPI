using AutoMapper;
using LearnHub.Application.Courses.Dtos;
using LearnHub.Application.Qualifications.Dtos;
using LearnHub.Application.Qualifications.Interfaces;
using LearnHub.Domain.Entities;
using LearnHub.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Qualifications.Services
{
    public class QualificationService(IQualificationRepository qualificationRepository, IMapper mapper) : IQualificationService
    {
        private readonly IQualificationRepository _qualificationRepository = qualificationRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<List<GetQualification>> GetAllQualificationsAsync()
        {
            var qualification = await _qualificationRepository.GetAllAsync();
            return qualification.Select(grade => _mapper.Map<GetQualification>(grade)).ToList();
        }

        public async Task<GetQualification?> GetQualificationByCodeAsync(string qualificationCode)
        {
            var qualification = await _qualificationRepository.GetbyCodeAsync(qualificationCode);
            return _mapper.Map<GetQualification>(qualification);
        }

        public async Task<GetQualification> AddQualificationAsync(CreateQualification createQualification, string studentCode, string assignmentCode, string teacherCode)
        {
            var qualification = new Qualification
            {
                Score = createQualification.Score,
            };
            var newQualification = await _qualificationRepository.AddAsync(qualification,studentCode,assignmentCode,teacherCode);
            return _mapper.Map<GetQualification>(newQualification);
        }

        public async Task<GetQualification?> UpdateQualificationAsync(int id, CreateQualification updateQualification, string studentCode, string assignmentCode)
        {
            var qualification = new Qualification
            {
                Score = updateQualification.Score,
            };
            var newQualification = await _qualificationRepository.UpdateAsync(id,qualification, studentCode, assignmentCode);
            return _mapper.Map<GetQualification>(newQualification);
        }

        public async Task<List<GetQualification>?> DeleteQualificationAsync(string qualificationCode)
        {
            var qualification = await _qualificationRepository.DeleteAsync(qualificationCode);
            return qualification?.Select(grade => _mapper.Map<GetQualification>(grade)).ToList();
        }

    }
}
