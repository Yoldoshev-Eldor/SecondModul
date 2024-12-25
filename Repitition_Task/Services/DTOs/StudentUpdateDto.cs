namespace Repitition_Task.Services.DTOs;

public class StudentUpdateDto : BaseDto
{
    public Guid Id { get; set; }
    public string Password { get; set; }
}
