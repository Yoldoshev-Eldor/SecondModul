﻿namespace Lesson6.Services.DTOs
{
    public class StudentUpdateDto : BaseStudentDto
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
    }
}
