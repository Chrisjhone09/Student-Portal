﻿namespace serverSide.DTO
{
    public class RegisterDTO
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Program { get; set; }
        public string Password { get; set; }
        public string StudentId { get; set; }
    }
}
