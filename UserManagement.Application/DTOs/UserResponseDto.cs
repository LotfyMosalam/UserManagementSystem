using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Application.DTOs
{
    public class UserResponseDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string UserFullName { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
