namespace UserManagement.API.Models
{
    public class UserCreateRequest
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string UserFullName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
