using lesson8_HMWRK.DataAccess.Entities;
using System.Text.Json;

namespace lesson8_HMWRK.Repostories;

public class SchoolRepostorie : ISchoolRepostorie
{
    private readonly string _path;
    private List<School> _schools;
    public SchoolRepostorie()
    {
        _path = "../../../DataAccess/Data/School.json";
        _schools = new List<School>();
        if(!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }
        _schools = GetSchoolList();

    }
    public School GetSchoolById(Guid schoolId)
    {
       foreach(School school in _schools)
        {
            if (schoolId == school.Id)
            {
                return school;
            }
        }
        throw new Exception("not Found This id school ");
    }

    public List<School> GetSchoolList()
    {
        var studentJson = File.ReadAllText(_path);
        var schoolList = JsonSerializer.Deserialize<List<School>>(studentJson);
        return schoolList;
    }

    public void RemoveSchool(Guid schoolId)
    {
       var school = GetSchoolById(schoolId);
        _schools.Remove(school);
        SaveData();
    }

    public void UpdateStudent(School school)
    {
       var UpdateSchool = GetSchoolById(school.Id);
        var index = _schools.IndexOf(UpdateSchool);
        _schools[index] = school;
        SaveData();
    }

    public Guid WriteSchool(School school)
    {
        _schools.Add(school);
        SaveData() ;
        return school.Id;
    }
    private void SaveData()
    {
        var jsonFile = JsonSerializer.Serialize(_schools);
        File.WriteAllText(_path,jsonFile);
    }
}
