using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Requests;
using Business.DTOs;
using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private UniversityContractService _service;

        public ContractController(UniversityContractService service)
        {
            _service = service;
        }

        [HttpGet("/{userId}")]
        public List<AnnualContractDetails> GetContractSetupDetails(int userId)
        {
            return _service.GetContractDetails(userId);
        }

        [HttpPost()]
        public void AddAnnualContract(AddAnnualContractRequest contractDetails)
        {
            _service.CreateContract(new AddAnnualContract
            {
                UserId = contractDetails.UserId,
                Year = contractDetails.Year,
                CourseIds = contractDetails.CourseIds
            });
        }
    }
}