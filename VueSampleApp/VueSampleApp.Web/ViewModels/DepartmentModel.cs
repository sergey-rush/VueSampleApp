using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace VueSampleApp.Web.ViewModels
{
    [JsonObject(Title = "Department")]
    public class DepartmentModel
    {
        public int Id { get; set; }

        [MaxLength(32)]
        public string Title { get; set; }
    }
}
