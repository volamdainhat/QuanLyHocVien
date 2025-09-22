﻿using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.Grades;
using StudentManagementApp.Infrastructure.Data;

namespace StudentManagementApp.Infrastructure.Repositories.Gradeses
{
    public class GradesRepository : Repository<Grades>, IGradesRepository
    {
        public GradesRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<GradesViewModel>> GetGradesWithTraineeSubjectAsync()
        {
            return await (from grades in _context.Grades
                          join traineeEntity in _context.Trainees on grades.TraineeId equals traineeEntity.Id into traineeJoin
                          from traineeObj in traineeJoin.DefaultIfEmpty()
                          join subjectEntity in _context.Subjects on grades.SubjectId equals subjectEntity.Id into subjectJoin
                          from subjectObj in subjectJoin.DefaultIfEmpty()
                          join examType in _context.Categories on
                              new { Code = grades.ExamType, Type = "ExamType" }
                              equals new { examType.Code, examType.Type } into examTypeJoin
                          from examTypeObj in examTypeJoin.DefaultIfEmpty()
                          select new GradesViewModel
                          {
                              Id = grades.Id,
                              TraineeName = traineeObj != null ? traineeObj.FullName : "",
                              SubjectName = subjectObj != null ? subjectObj.Name : "",
                              ExamType = examTypeObj != null ? examTypeObj.Name : "",
                              Grade = grades.Grade,
                              CreatedDate = grades.CreatedDate,
                              ModifiedDate = grades.ModifiedDate,
                              IsActive = grades.IsActive
                          }).ToListAsync();
        }

        public async Task<Grades> GetGradesWithDetailsAsync(int id)
        {
            return await _context.Grades
                .Include(c => c.Trainee)
                .Include(c => c.Subject)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
