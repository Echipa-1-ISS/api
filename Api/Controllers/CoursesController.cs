using Business.DTOs;
using Business.Services;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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


}
