using System.Collections.Generic;

namespace VueSampleApp.Services.Department
{
    public interface IDepartmentService
    {
        List<Data.Models.Department> GetAllDepartments();
        ServiceResponse<Data.Models.Department> UpdateDepartment(Data.Models.Department profile);
        ServiceResponse<Data.Models.Department> CreateDepartment(Data.Models.Department profile);
        Data.Models.Department GetByDepartmentId(int id);
        ServiceResponse<bool> DeleteDepartment(int id);
    }
}
