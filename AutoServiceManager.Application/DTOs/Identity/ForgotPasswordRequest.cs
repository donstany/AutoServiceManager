﻿using System.ComponentModel.DataAnnotations;

namespace AutoServiceManager.Application.DTOs.Identity
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}