using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Common;

namespace UserManagement.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string UserFullName { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        // Required by ORM (EF Core)
        private User() { }

        public User(
            string username,
            string password,
            string userFullName,
            DateTime dateOfBirth,
            bool isActive = true)
        {
            SetUsername(username);
            SetPassword(password);
            SetUserFullName(userFullName);
            SetDateOfBirth(dateOfBirth);

            IsActive = isActive;
        }

        public void Update(
            string username,
            string password,
            string userFullName,
            DateTime dateOfBirth,
            bool isActive)
        {
            SetUsername(username);
            SetPassword(password);
            SetUserFullName(userFullName);
            SetDateOfBirth(dateOfBirth);
            IsActive = isActive;
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        private void SetUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username is required");

            Username = username.Trim();
        }

        private void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password is required");

            Password = password;
        }

        private void SetUserFullName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Full name is required");

            UserFullName = fullName.Trim();
        }

        private void SetDateOfBirth(DateTime dateOfBirth)
        {
            if (dateOfBirth >= DateTime.UtcNow)
                throw new ArgumentException("Date of birth must be in the past");

            DateOfBirth = dateOfBirth;
        }
    }
}

