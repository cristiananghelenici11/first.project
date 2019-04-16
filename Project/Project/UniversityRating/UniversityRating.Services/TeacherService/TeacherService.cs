﻿using System.Collections.Generic;
using AutoMapper;
using UniversityRating.Data.Abstractions.Models.Teacher;
using UniversityRating.Data.Abstractions.Repositories;
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
    }
}