﻿using Business.DTOs;
using Business.Services;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Api.Requests;

namespace Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase {
    private UMSDatabaseContext _context;
    private CoursesService _service;

    public CoursesController(UMSDatabaseContext context, CoursesService service) {
        _context = context;
        _service = service;
    }

    [HttpGet("courses")]
    [AllowAnonymous]
    public List<Courses> GetCourses() {
        return _context.Courses.ToList();
    }


    [HttpGet("semestersAndSpecializations")]
    [AllowAnonymous]
    public SemestersAndSpecializationsResponse GetSemestersAndSpecializations() {
        return _service.GetSemestersAndSpecializations();
    }

    [AllowAnonymous]
    [HttpPost("addOptional")]
    public int AddOptionalCourse(AddOptionalCourseRequest request)
    {
        var teacherId = _context.Teachers.Where(o => o.UserId == request.UserId).Select(o => o.Id).SingleOrDefault();
        var noOptionalCourses = _context.Courses.Where(o => (o.TeacherId == teacherId) && (o.OptionalFlag.Equals(true)))
            .Count();

        if (noOptionalCourses == 2) return 0;
        else
        {
            var optionalCourse = new Courses
            {
                DisciplineName = request.Name,
                TeacherId = teacherId,
                SemesterId = request.SemesterId,
                OptionalFlag = true,
                NumberOfStudents = 0,
                SpecializationID = request.SpecializationId
            };
            _context.Courses.Add(optionalCourse);
            _context.SaveChanges();

            noOptionalCourses++;
            return 2 - noOptionalCourses;
        }
    }
  

    [AllowAnonymous]
    [HttpPost("approveCourse")]
     public int ApproveCourse(ApproveOptionalCourseRequest request)
      {
        var courseRows = _context.Courses.Where(o => o.Id == request.CourseId).Count();

        // var contact = new Contact{Id = 1};
        // contact.FirstName = "Something new";
        // context.Entry(contact).Property("FirstName").IsModified = true;
        // context.SaveChanges();

        if (courseRows >= 1)
        {
            var Course = new Courses { Id = request.CourseId };
            Course.NumberOfStudents = request.MaxStudents;
            _context.Entry(Course).Property("NumberOfStudents").IsModified = true;
            _context.SaveChanges();

            return 1;
        }
        else
            return 0; // to do handle error somehow
    }


}
