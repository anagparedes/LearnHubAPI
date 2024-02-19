using AutoMapper;
using LearnHub.Application.Courses.Dtos;
using LearnHub.Application.Courses.Interfaces;
using LearnHub.Application.Students.Dtos;
using LearnHub.Application.Users.Dtos;
using LearnHub.Domain.Entities;
using LearnHub.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Courses.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository, IConfiguration configuration, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _configuration = configuration;
            _mapper = mapper;
        }
        public async Task<List<GetCourse>> GetAllCoursesAsync()
        {
            var course = await _courseRepository.GetAllAsync();
            return course.Select(subject => _mapper.Map<GetCourse>(subject)).ToList();
        }
        public async Task<GetCourse?> GetCourseByCodeAsync(string courseCode)
        {
            var course = await _courseRepository.GetbyCodeAsync(courseCode);
            return _mapper.Map<GetCourse>(course);
        }
        public async Task<GetCourseWithStudent?> GetCourseWithStudentAsync(string courseCode)
        {
            var course = await _courseRepository.GetCourseWithStudentAsync(courseCode);
            return _mapper.Map<GetCourseWithStudent>(course);
        }
        public async Task<GetCourse> AddInPersonCourseAsync(CreateCourse createCourse)
        {
            var course = new Course
            {
                CourseName = createCourse.CourseName,
                Period = createCourse.Period,
                Year = createCourse.Year,
            };
            var newCourse = await _courseRepository.AddInPersonCourseAsync(course);
            return _mapper.Map<GetCourse>(newCourse);
        }

        public async Task<GetCourse> AddOnlineCourseAsync(CreateCourse createCourse)
        {
            var course = new Course
            {
                CourseName = createCourse.CourseName,
                Period = createCourse.Period,
                Year = createCourse.Year,
            };
            var newCourse = await _courseRepository.AddOnlineCourseAsync(course);
            return _mapper.Map<GetCourse>(newCourse);
        }

        public async Task<GetCourseWithStudent?> AddStudentsToCourse(string courseCode, string studentCode)
        {
            var course = await _courseRepository.AddStudentsToCourse(courseCode,studentCode);
            return _mapper.Map<GetCourseWithStudent>(course);
        }

        public async Task<GetCourseWithTeacher?> AddTeacherToCourse(string courseCode, string teacherCode)
        {
            var course = await _courseRepository.AddTeacherToCourse(courseCode, teacherCode);
            return _mapper.Map<GetCourseWithTeacher>(course);
        }

        public async Task<GetCourseWithAssignment?> AddAssignmentsToCourse(string courseCode, string assignmentCode)
        {
            var course = await _courseRepository.AddStudentsToCourse(courseCode, assignmentCode);
            return _mapper.Map<GetCourseWithAssignment>(course);
        }

        public async Task<GetCourse?> UpdateCourseAsync(int id, CreateCourse createCourse)
        {
            var course = new Course
            {
                CourseName = createCourse.CourseName,
                Period = createCourse.Period,
                Year = createCourse.Year,
            };
            var newCourse = await _courseRepository.UpdateAsync(id, course);
            return _mapper.Map<GetCourse>(newCourse);
        }

        public async Task<List<GetCourse>?> DeleteCourseAsync(string courseCode)
        {
            var course = await _courseRepository.DeleteAsync(courseCode);
            return course?.Select(cos => _mapper.Map<GetCourse>(cos)).ToList();
        }

    }
}
