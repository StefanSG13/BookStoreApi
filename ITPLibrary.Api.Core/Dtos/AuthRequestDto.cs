﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPLibrary.Api.Core.Dtos
{
    public class AuthRequestDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(20)]
        public string Passwrod { get; set; }
    }
}
