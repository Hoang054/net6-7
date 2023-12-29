﻿using System.ComponentModel.DataAnnotations;

namespace CharityClinic.Services
{
    public class LoginViewModel
    {
        [Required]
        //[EmailAddress]
        public string? UserId { get; set; }
        public string? Email { get; set; }

        [Required]
        //[DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
