using lesson8_HMWRK.Services.DTOs;

namespace lesson8_HMWRK.Services
{
    public interface ISchoolService
    {
        public Guid AddSchool(SchoolCreateDto school);
        public void DeleteSchool(Guid id);
        public List<SchoolDto> GetSchoolList();
        public void UpdateSchool(SchoolDto school);
    }
}