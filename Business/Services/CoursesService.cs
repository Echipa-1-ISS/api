using Business.DTOs;
using Data;
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
        _context.Specializations.ToList().ForEach(s => SemestersAndSpecializations.Specializations.Add(new SpecializationDTO { Id = s.Id, Name = s.Name }));
        _context.Semesters.ToList().ForEach(s => SemestersAndSpecializations.Semesters.Add(new SemesterDTO { Id = s.Id, SemesterDetails = s.SemesterDetails, UniversityYearID = s.UniversityYearID }));

        return SemestersAndSpecializations;
    }
}
