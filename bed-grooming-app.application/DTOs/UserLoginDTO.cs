using System;
using System.Collections.Generic;
using System.Text;

namespace bed_grooming_app.application.DTOs
{
    public class UserLoginDTO
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string? TenantId { get; set; }
    }
}
