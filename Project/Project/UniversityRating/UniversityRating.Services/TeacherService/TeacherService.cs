using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using UniversityRating.Data.Abstractions.Models.Teacher;
using UniversityRating.Data.Abstractions.Repositories;
using UniversityRating.Data.Core.DomainModels;
using UniversityRating.Services.Abstractions;
using UniversityRating.Services.Common.DTOs.Teacher;

namespace UniversityRating.Services.TeacherService
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public TeacherService(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        public List<TopTeacherDto> GetTopTeachers(int numberOfTeachers)
        {
                
            List<Teacher> teachers = _teacherRepository.GetTopTeachers(numberOfTeachers);
            List<TopTeacher> topTeachers = _mapper.Map<List<Teacher>, List<TopTeacher>>(teachers);
            topTeachers.OrderByDescending(x => x.MarkAvg);

            return _mapper.Map<List<TopTeacher>, List<TopTeacherDto>>(topTeachers);
        }

        public List<TeacherShowDto> GetAllTeachers()
        {
            List<Teacher> teachers = _teacherRepository.GetAllTeachers();
            List<TeacherShow> teacherShows = _mapper.Map<List<Teacher>, List<TeacherShow>>(teachers);

            return _mapper.Map<List<TeacherShow>, List<TeacherShowDto>>(teacherShows);
        }

        public List<TeacherShowDto> GetAllTeachersByUniversityId(long universityId)
        {
            List<Teacher> teachers = _teacherRepository.GetAllTeachersByUniversityId(universityId);
            List<TeacherShow> teacherShows = _mapper.Map<List<Teacher>, List<TeacherShow>>(teachers);
            
            return _mapper.Map<List<TeacherShow>, List<TeacherShowDto>>(teacherShows);
        }

        public List<TeacherShowDto> GetAllTeachersWithoutUniversity()
        {
            List<Teacher> teachers = _teacherRepository.GetAllTeachersWithoutUniversity();
            List<TeacherShow> teacherShows = _mapper.Map<List<Teacher>, List<TeacherShow>>(teachers);

            return _mapper.Map<List<TeacherShow>, List<TeacherShowDto>>(teacherShows);
        }

        public void Update(TeacherDto teacherDto)
        {
            _teacherRepository.Update(_mapper.Map<Teacher>(teacherDto));
            _teacherRepository.SaveChanges();
        }

        public void DeleteTeacherById(int id)
        {
            _teacherRepository.DeleteTeacherById(id);
        }

        public void AddTeacher(TeacherDto teacherDto)
        {
            _teacherRepository.Add(_mapper.Map<Teacher>(teacherDto));
            _teacherRepository.SaveChanges();
        }

        public List<TeacherShowDto> GetAllTeachersByUniversityId(long universityId, int pageNumber, string search, int numberOfRecordsPerPage,
            bool skipRecords)
        {
            List<TeacherShow> teacherShow = _teacherRepository.GetAllTeachersByUniversityId(universityId, pageNumber, search, numberOfRecordsPerPage, skipRecords);
            List<TeacherShowDto> teacherShowDto = _mapper.Map<List<TeacherShowDto>>(teacherShow);

            return teacherShowDto;
        }
    }
}