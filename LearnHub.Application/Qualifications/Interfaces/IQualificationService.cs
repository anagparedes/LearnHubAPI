using LearnHub.Application.Qualifications.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Qualifications.Interfaces
{
    public interface IQualificationService
    {
        Task<List<GetQualification>> GetAllQualificationsAsync();
        Task<GetQualification?> GetQualificationByCodeAsync(string qualificationCode);
        Task<GetQualification> AddQualificationAsync(CreateQualification createQualification, string studentCode, string assignmentCode, string teacherCode);
        Task<GetQualification?> UpdateQualificationAsync(int id, CreateQualification updateQualification, string studentCode, string assignmentCode);
        Task<List<GetQualification>?> DeleteQualificationAsync(string qualificationCode);
    }
}
