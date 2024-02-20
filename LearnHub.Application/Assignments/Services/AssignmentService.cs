using AutoMapper;
using LearnHub.Application.Assignments.Dtos;
using LearnHub.Application.Assignments.Interfaces;
using LearnHub.Application.Courses.Dtos;
using LearnHub.Domain.Entities;
using LearnHub.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Assignments.Services
{
    public class AssignmentService(IAssignmentRepository assignmentRepository, IConfiguration configuration, IMapper mapper) : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository = assignmentRepository;
        private readonly IConfiguration _configuration = configuration;
        private readonly IMapper _mapper = mapper;

        public async Task<List<GetAssignment>> GetAllAssignmentAsync()
        {
            var assignment = await _assignmentRepository.GetAllAsync();
            return assignment.Select(work => _mapper.Map<GetAssignment>(work)).ToList();
        }

        public async Task<GetAssignmentWithStudent?> GetAssignmentWithStudentAsync(string assignmentCode)
        {
            var assignment = await _assignmentRepository.GetAssignmentWithStudentAsync(assignmentCode);
            return _mapper.Map<GetAssignmentWithStudent>(assignment);
        }

        public Task<GetAssignmentWithCourse?> GetAssignmentWithCourseAsync(string assignmentCode)
        {
            throw new NotImplementedException();
        }

        public Task<GetAssignmentWithTeacher?> GetAssignmentWithTeacherAsync(string assignmentCode)
        {
            throw new NotImplementedException();
        }

        public async Task<GetAssignment?> GetAssignmentByCodeAsync(string assignmentCode)
        {
            var assignment = await _assignmentRepository.GetbyCodeAsync(assignmentCode);
            return _mapper.Map<GetAssignment>(assignment);
        }

        public async Task<GetAssignment> AddAssignmentAsync(CreateAssignment createAssignment)
        {
            var assignment = new Assignment
            {
                Title = createAssignment.Title,
                Description = createAssignment.Description,
            };
            var newAssignment = await _assignmentRepository.AddAsync(assignment);
            return _mapper.Map<GetAssignment>(newAssignment);
        }

        public async Task<GetAssignmentWithCourse?> AddCourseToAssignment(string assignmentCode, string courseCode)
        {
            var assignment = await _assignmentRepository.AddCourseToAssignment(assignmentCode, courseCode);
            return _mapper.Map<GetAssignmentWithCourse>(assignment);
        }

        public async Task<GetAssignmentWithStudent?> AddStudentsToAssignment(string assignmentCode, string studentCode)
        {
            var assignment = await _assignmentRepository.AddStudentsToAssignment(assignmentCode, studentCode);
            return _mapper.Map<GetAssignmentWithStudent>(assignment);
        }

        public async Task<GetAssignmentWithTeacher?> AddTeacherToAssignment(string assignmentCode, string teacherCode)
        {
            var assignment = await _assignmentRepository.AddTeacherToAssignment(assignmentCode, teacherCode);
            return _mapper.Map<GetAssignmentWithTeacher>(assignment);
        }
        public async Task<GetAssignmentWithStudentResponse?> UpdateWithStudentResponseAsync(int id, UpdateAssignmentWithStudentResponse updateAssignment)
        {
            var assignment = new Assignment
            {
                StudentResponse = updateAssignment.StudentResponse,
            };
            var newAssignment = await _assignmentRepository.UpdateAsync(id, assignment);
            return _mapper.Map<GetAssignmentWithStudentResponse>(newAssignment);
        }
        public async Task<GetAssignment?> UpdateAssignmentAsync(int id, CreateAssignment createAssignment)
        {
            var assignment = new Assignment
            {
                Title = createAssignment.Title,
                Description = createAssignment.Description,
            };
            var newAssignment = await _assignmentRepository.UpdateAsync(id, assignment);
            return _mapper.Map<GetAssignment>(newAssignment);
        }
        public async Task<List<GetAssignment>?> DeleteAssignmentAsync(string assignmentCode)
        {
            var assignment = await _assignmentRepository.DeleteAsync(assignmentCode);
            return assignment?.Select(assign => _mapper.Map<GetAssignment>(assign)).ToList();
        }
    }
}
