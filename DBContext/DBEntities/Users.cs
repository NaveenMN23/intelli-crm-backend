﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using IntelliCRMAPIService.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntelliCRMAPIService
{
    public partial class Users
    {
        [Key]
        public int UserId { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string RoleName { get; set; }

        [NotMapped]
        public Role Role { get; set; }
        public int? AccountStatus { get; set; }
        public int? AccountType { get; set; }
        public bool? RightsForCustomerAccount { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        [NotMapped]
        public string? RefreshToken { get;set; }

        [NotMapped]
        public DateTime? RefreshTokenExpiry { get; set; }
    }
}