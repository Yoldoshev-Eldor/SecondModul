using Exam_tasks.DataAccess.Entities;
using Exam_tasks.Repostories;
using Exam_tasks.Services.DTOs;

namespace Exam_tasks.Services;

public class UserService : IUserService
{
    private readonly IUserRepostory _userRepo;
    public UserService()
    {
        _userRepo = new UserRepostory();
    }
    private User ConvertToEntitieCreate(CreateDto createUser)
    {
        return new User
        {
            Id = Guid.NewGuid(),
            FirstName = createUser.FirstName,
            LastName = createUser.LastName,
            Email = createUser.Email,
            Password = createUser.Password,
            Age = createUser.Age,
        };
    }
    private User ConvertToEntitieUpdate(UpdateDto updateUser)
    {
        return new User
        {
            Id = updateUser.Id,
            FirstName = updateUser.FirstName,
            LastName = updateUser.LastName,
            Email = updateUser.Email,
            Password = updateUser.Password,
            Age = updateUser.Age,
        };
    }
    private GetDto ConvertToDto(User user)
    {
        return new GetDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Age= user.Age,
        };
    }
    public Guid AddUser(CreateDto newUser)
    {
       // validateUserCreateDto(newUser);
       // ConvertUser(newUser);
       // var userNew = Guid.NewGuid();
       // _userRepo.EmailConsist(userNew);
       // _userRepo.WriteUser(userNew);
       // return ConvertUser(userNew);
       _userRepo.WriteUser(ConvertToEntitieCreate(newUser));
        return ConvertToEntitieCreate(newUser).Id;
    }

    public void DeleteUser(Guid userId)
    {
        _userRepo.RemoveUser(userId);

    }

    public GetDto GetUserById(Guid userId)
    {
      var userEntitie =  _userRepo.GetUserById(userId);
        var result = ConvertToDto(userEntitie);
        return result;

       
    }

    public List<GetDto> GetUsers()
    {
       var usersDto = new List<GetDto>();
        var usersEntitie = _userRepo.ReadAllUsers();
        foreach(var user in usersEntitie)
        {
            usersDto.Add(ConvertToDto(user));
        }
        return usersDto;
       
    }

    public void UpdateUser(UpdateDto updatingUser)
    {
        var updateStudent = ConvertToEntitieUpdate(updatingUser);
        _userRepo.UpdateUser(updateStudent);
    }
}
