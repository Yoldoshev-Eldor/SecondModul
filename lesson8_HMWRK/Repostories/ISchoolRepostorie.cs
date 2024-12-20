using lesson8_HMWRK.DataAccess.Entities;

namespace lesson8_HMWRK.Repostories
{
    public interface ISchoolRepostorie
    {
        Guid WriteSchool(School school);
        List<School> GetSchoolList();
        void RemoveSchool(Guid schoolId);
        School GetSchoolById(Guid schoolId);
        void UpdateStudent(School school);

    }
}