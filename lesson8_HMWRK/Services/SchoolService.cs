using lesson8_HMWRK.DataAccess.Entities;
using lesson8_HMWRK.Repostories;
using lesson8_HMWRK.Services.DTOs;
using System.ComponentModel;

namespace lesson8_HMWRK.Services;

public class SchoolService : ISchoolService
{
    private readonly ISchoolRepostorie SchoolRepo;
    public SchoolService()
    {
        SchoolRepo = new SchoolRepostorie();

    }
    private School ConvertToEntitie(SchoolCreateDto school)
    {
        return new School
        {
            Id = Guid.NewGuid(),
            Number = school.Number,
            Region = school.Region,
            District = school.District,
        };
    }
    private SchoolDto ConvetToDto(School school)
    {
        return new SchoolDto
        {
            Id = school.Id,
            Number = school.Number,
            Region = school.Region,
            District = school.District,
        };
    }
    public Guid AddSchool(SchoolCreateDto school)
    {
        SchoolRepo.WriteSchool(ConvertToEntitie(school));
        return ConvertToEntitie(school).Id;
    }
    public void DeleteSchool(Guid id)
    {
        SchoolRepo.RemoveSchool(id);
    }
    public List<SchoolDto> GetSchoolList()
    {
        var schoolList = new List<SchoolDto>();
        var repo = SchoolRepo.GetSchoolList();
        foreach (var school in repo)
        {
           var adding = ConvetToDto(school);
            schoolList.Add(adding);
        } 
        return schoolList;
    }
    public void UpdateSchool(SchoolDto school)
    {
        SchoolRepo.UpdateStudent(ConvertToEntitie(school));
    }
}
