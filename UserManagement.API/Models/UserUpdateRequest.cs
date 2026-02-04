namespace UserManagement.API.Models
{
    public class UserUpdateRequest
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string UserFullName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; }
    }
}
