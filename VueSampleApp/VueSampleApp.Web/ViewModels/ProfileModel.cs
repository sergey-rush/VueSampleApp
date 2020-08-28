using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VueSampleApp.Data.Models;

namespace VueSampleApp.Web.ViewModels
{
    public class ProfileModel
    {
        [JsonProperty("profileId")]
        public int Id { get; set; }

        [MaxLength(32)]
        public string FirstName { get; set; }

        [MaxLength(32)]
        public string LastName { get; set; }

        [JsonProperty("department")]
        public DepartmentModel DepartmentModel { get; set; }
    }
}
