using VueSampleApp.Data.Models;
using VueSampleApp.Web.ViewModels;

namespace VueSampleApp.Web.Extensions
{
    public static class DepartmentExtensions
    {
        public static DepartmentModel ToDepartmentModel(this Department department)
        {
            return new DepartmentModel
            {
                Id = department.Id,
                Title = department.Title
            };
        }

        public static Department ToDepartment(this DepartmentModel model)
        {
            return new Department
            {
                Id = model.Id,
                Title = model.Title
            };
        }
    }
}
