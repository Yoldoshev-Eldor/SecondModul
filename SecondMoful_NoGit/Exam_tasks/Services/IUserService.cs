using Exam_tasks.Services.DTOs;

namespace Exam_tasks.Services;

public interface IUserService
{
    Guid AddUser(CreateDto newUser);
    void DeleteUser(Guid userId);
    GetDto GetUserById(Guid userId);
    List<GetDto> GetUsers();
    void UpdateUser(UpdateDto UpdatingUser);

}