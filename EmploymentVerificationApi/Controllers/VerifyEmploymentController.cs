using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EmploymentVerificationApi.Models;

namespace EmploymentVerificationApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class VerifyEmploymentController : ControllerBase
    {
        // In-memory data structure for employee records
        private static readonly List<Employee> Employees = new List<Employee>
        {
            new Employee { EmployeeId = 1, CompanyName = "HCL", VerificationCode = "HCL1212" },
            new Employee { EmployeeId = 2, CompanyName = "Dignitas Digital", VerificationCode = "DD789789" },
            new Employee { EmployeeId = 3, CompanyName = "Acme", VerificationCode = "ACM123123" }
        };

        [HttpPost("verify-employment")]
        public async Task<IActionResult> VerifyEmployment([FromBody] EmploymentVerificationRequest request)
        {
            if (request == null)
                return BadRequest("Invalid request");

            var employee = await Task.Run(() =>
            {
                return Employees.Find(e =>
                    e.EmployeeId == request.EmployeeId &&
                    e.CompanyName == request.CompanyName &&
                    e.VerificationCode == request.VerificationCode);
            });

            if (employee == null)
                return Ok(new { Verified = false });
            else
                return Ok(new { Verified = true });
        }
    }
}