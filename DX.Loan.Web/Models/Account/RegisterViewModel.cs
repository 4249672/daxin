﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Abp.Auditing;
using DX.Loan.Authorization.Users;
using DX.Loan.MultiTenancy;
using DX.Loan.Security;
using Abp.Extensions;
using DX.Loan.Validation;

namespace DX.Loan.Web.Models.Account
{
    public class RegisterViewModel : IValidatableObject
    {
        /// <summary>
        /// Not required for single-tenant applications.
        /// </summary>
        [StringLength(Tenant.MaxTenancyNameLength)]
        public string TenancyName { get; set; }

        //[Required]
        //[StringLength(User.MaxNameLength)]
        //public string Name { get; set; }

        //[Required]
        //[StringLength(User.MaxSurnameLength)]
        //public string Surname { get; set; }

        [StringLength(User.MaxUserNameLength)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(User.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }

        [StringLength(User.MaxPlainPasswordLength)]
        [DisableAuditing]
        public string Password { get; set; }

        public bool IsExternalLogin { get; set; }

        public PasswordComplexitySetting PasswordComplexitySetting { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!UserName.IsNullOrEmpty())
            {
                if (!UserName.Equals(EmailAddress) && new ValidationHelper().IsEmail(UserName))
                {
                    yield return new ValidationResult("Username cannot be an email address unless it's same with your email address !");
                }
            }
        }
    }
}