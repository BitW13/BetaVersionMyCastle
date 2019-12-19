using System;
using System.ComponentModel.DataAnnotations;
using AuthService.WebApi.Data;

namespace AuthService.WebApi.Models
{
    public class LoginInputModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberLogin { get; set; }

        public string ReturnUrl { get; set; }
    }
}
