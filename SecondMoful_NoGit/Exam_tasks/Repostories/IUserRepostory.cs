using Exam_tasks.DataAccess.Entities;

namespace Exam_tasks.Repostories
{
    public interface IUserRepostory
    {
        Guid WriteUser(User user);
        User GetUserById(Guid id);
        void RemoveUser(Guid id);
        void UpdateUser(User user);
        List<User> ReadAllUsers();


    }
}