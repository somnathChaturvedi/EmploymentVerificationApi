﻿namespace EmploymentVerificationApi.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string? CompanyName { get; set; }
        public string? VerificationCode { get; set; }
    }
}
