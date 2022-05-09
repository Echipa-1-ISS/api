﻿using Business.DTOs;
using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services;
public class CoursesService {
    private UMSDatabaseContext _context;

    public CoursesService(UMSDatabaseContext context) {
        _context = context;
    }

    public SemestersAndSpecializationsResponse GetSemestersAndSpecializations() {
        SemestersAndSpecializationsResponse SemestersAndSpecializations = new SemestersAndSpecializationsResponse();
        SemestersAndSpecializations.Semesters = new List<SemesterDTO>();
        SemestersAndSpecializations.Specializations = new List<SpecializationDTO>();
        _context.Specializations.ToList().ForEach(
            s => SemestersAndSpecializations.Specializations.Add(
                new SpecializationDTO { Id = s.Id, Name = s.Name }
            ));
        _context.Semesters.ToList().ForEach(
            s => SemestersAndSpecializations.Semesters.Add(
                new SemesterDTO { 
                    Id = s.Id, 
                    SemesterDetails = s.SemesterDetails, 
                    UniversityYear = _context.UniversityYears.FirstOrDefault(y => y.Id == s.UniversityYearID).Year 
                })
            );

        return SemestersAndSpecializations;
    }

    public void updateCourse(int id, int maxStudents)
    {
        var course = new Courses { Id = id };
        course.NumberOfStudents = maxStudents;
        _context.Entry(course).Property("NumberOfStudents").IsModified = true;
        _context.SaveChanges();
    }
}
