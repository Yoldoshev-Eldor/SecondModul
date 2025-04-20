namespace Exam_tasks.Services.DTOs;

public class UpdateDto : BaseDto
{
    public string Password { get; set; }
    public Guid Id { get; set; }
}
