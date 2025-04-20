using Exam_tasks.DataAccess.Entities;
using System.Text.Json;

namespace Exam_tasks.Repostories;
public class UserRepostory : IUserRepostory
{
    private readonly string _path;
    private List<User> _users;
    public UserRepostory()
    {
        _path = "../../../DataAccess/Data/Users.json";
        _users = new List<User>();
        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }
        _users = ReadAllUsers();
    }
    public User GetUserById(Guid id)
    {
        foreach (var user in _users)
        {
            if (user.Id == id)
            {
                return user;
            }
        }
        throw new Exception("No such student found");
    }

    public List<User> ReadAllUsers()
    {
        var userJson = File.ReadAllText(_path);
        var usersList = JsonSerializer.Deserialize<List<User>>(userJson);
        return usersList;
    }

    public void RemoveUser(Guid id)
    {
        var removeUser  = GetUserById(id);
        _users.Remove(removeUser);
        SaveData();
    }

    public void UpdateUser(User user)
    {
       var updateUser = GetUserById(user.Id);
        var index = _users.IndexOf(updateUser);
        _users[index] = updateUser;
    }

    public Guid WriteUser(User user)
    {
        _users.Add(user);
        SaveData();
        return user.Id;
    }
    private void SaveData()
    {
        var jsonUsers = JsonSerializer.Serialize( _users);
        File.WriteAllText( _path, jsonUsers );
    }

}
