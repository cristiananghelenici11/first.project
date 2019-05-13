using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using UniversityRating.Data.Abstractions.Extensions;
using UniversityRating.Data.Abstractions.Models.Teacher;
using UniversityRating.Data.Abstractions.Repositories;
using UniversityRating.Data.Core.DomainModels;
using UniversityRating.Data.Repositories;
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
                
            List<TopTeacher> topTeachers = _teacherRepository.GetTopTeachers(numberOfTeachers);

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
            var spec = new Specification<Teacher>();
            spec.Include(s => s.MarkTeachers).Include(x => x.UniversityTeachers).ThenInclude(x => x.University);

            if (universityId == 0)
            {
                if (!string.IsNullOrEmpty(search))
                {
                    spec.Predicate = x =>
                        x.FirstName.ToUpper().Contains(search.ToUpper()) || x.LastName.ToUpper().Contains(search.ToUpper());
                }
                IEnumerable<Teacher> teachers = _teacherRepository.Find(spec);

                if (skipRecords)
                    teachers = teachers.Skip((pageNumber - 1) * numberOfRecordsPerPage);
                teachers = teachers.Take(numberOfRecordsPerPage);

                return _mapper.Map<List<TeacherShowDto>>(teachers);
            }


            if (!string.IsNullOrEmpty(search))
            {
                spec.Predicate = x =>
                    x.UniversityTeachers.Any(y => y.UniversityId.Equals(universityId)) &&
                    (x.FirstName.ToUpper().Contains(search.ToUpper()) || x.LastName.ToUpper().Contains(search.ToUpper()));
            }
            else
            {
                spec.Predicate = x => x.UniversityTeachers.Any(y => y.UniversityId.Equals(universityId));

            }

            IEnumerable<Teacher> allTeachers = _teacherRepository.Find(spec);
            if (skipRecords)
                allTeachers = allTeachers.Skip((pageNumber - 1) * numberOfRecordsPerPage);
            allTeachers = allTeachers.Take(numberOfRecordsPerPage);
            var cd = _mapper.Map<List<TeacherShowDto>>(allTeachers);
            Console.WriteLine(cd);
            return _mapper.Map<List<TeacherShowDto>>(allTeachers);

        }
    }
}