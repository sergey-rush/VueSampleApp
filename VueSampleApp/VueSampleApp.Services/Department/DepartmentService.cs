using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using VueSampleApp.Data;

namespace VueSampleApp.Services.Department
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DataContext _db;
        private readonly ILogger<DepartmentService> _logger;

        public DepartmentService(DataContext dbContext, ILogger<DepartmentService> logger)
        {
            _db = dbContext;
            _logger = logger;
        }

        public List<Data.Models.Department> GetAllDepartments()
        {
            return _db.Departments.OrderBy(pi => pi.Id).ToList();
        }

        public Data.Models.Department GetByDepartmentId(int id)
        {
            return _db.Departments.FirstOrDefault(pi => pi.Id == id);
        }

        public ServiceResponse<Data.Models.Department> UpdateDepartment(Data.Models.Department profile)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<Data.Models.Department> CreateDepartment(Data.Models.Department profile)
        {
            try
            {
                _db.Departments.Add(profile);
                _db.SaveChanges();
                return new ServiceResponse<Data.Models.Department>
                {
                    IsSuccess = true,
                    Message = "New profile added",
                    Time = DateTime.UtcNow,
                    Data = profile
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Data.Models.Department>
                {
                    IsSuccess = false,
                    Message = e.StackTrace,
                    Time = DateTime.UtcNow,
                    Data = profile
                };

            }
        }

        public ServiceResponse<bool> DeleteDepartment(int id)
        {
            throw new NotImplementedException();
        }
    }
}
