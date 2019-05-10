using System.Collections.Generic;
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
            List<TopTeacher> teachers = _teacherRepository.GetTopTeachers(numberOfTeachers);

            return _mapper.Map<List<TopTeacher>, List<TopTeacherDto>>(teachers);
        }

        public List<TeacherShowDto> GetAllTeachers()
        {
            List<TeacherShow> teacherShows = _teacherRepository.GetAllTeachers();

            return _mapper.Map<List<TeacherShow>, List<TeacherShowDto>>(teacherShows);
        }

        public List<TeacherShowDto> GetAllTeachersByUniversityId(long universityId)
        {
            List<TeacherShow> teachersByUniversityId = _teacherRepository.GetAllTeachersByUniversityId(universityId);

            return _mapper.Map<List<TeacherShow>, List<TeacherShowDto>>(teachersByUniversityId);
        }

        public List<TeacherShowDto> GetAllTeachersWithoutUniversity()
        {
            List<TeacherShow> teachersByUniversityId = _teacherRepository.GetAllTeachersWithoutUniversity();

            return _mapper.Map<List<TeacherShow>, List<TeacherShowDto>>(teachersByUniversityId);
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