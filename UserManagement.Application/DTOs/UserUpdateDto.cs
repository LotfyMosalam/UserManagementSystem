using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Application.DTOs
{
    public class UserUpdateDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string UserFullName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; }
    }
}
