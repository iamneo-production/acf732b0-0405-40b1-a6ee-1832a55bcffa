﻿using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class LoginModel
    {
            [Key]
            [System.Text.Json.Serialization.JsonIgnore]

            public int Id { get; set; }
            [Required]
            [EmailAddress]
            public string Email { get; set; }
            [Required]
            [MinLength(8)]
            public string Password { get; set; }

        }
    }

