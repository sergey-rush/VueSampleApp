using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VueSampleApp.Services.Department;
using VueSampleApp.Web.ViewModels;

namespace VueSampleApp.Web.Controllers
{
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService departmentService;
        private readonly ILogger<ProfileController> _logger;

        public DepartmentController(
            ILogger<ProfileController> logger,
            IDepartmentService departmentService
            )
        {
            this.departmentService = departmentService;
            _logger = logger;
        }

        [HttpGet("/api/department")]
        public ActionResult GetDepartments()
        {
            _logger.LogInformation("Getting departments");
            var departments = departmentService.GetAllDepartments();

            var departmentModels = departments.Select(p => new DepartmentModel
                {
                    Id = p.Id,
                    Title = p.Title
                })
                .OrderByDescending(p => p.Id).ToList();

            return Ok(departmentModels);
        }
    }
}
