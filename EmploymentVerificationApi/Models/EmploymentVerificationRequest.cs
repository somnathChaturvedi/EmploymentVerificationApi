using System.ComponentModel.DataAnnotations;

namespace EmploymentVerificationApi.Models
{
    public class EmploymentVerificationRequest
    {
        [Required(ErrorMessage = "Employee ID is required.")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Company name is required.")]
        public string? CompanyName { get; set; }

        [Required(ErrorMessage = "Verification code is required.")]
        public string? VerificationCode { get; set; }
    }
}
