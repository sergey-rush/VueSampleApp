using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VueSampleApp.Web.ViewModels
{
    public class AccountModel
    {
        [JsonProperty("accountId")]
        public int Id { get; set; }

        [MaxLength(32)]
        public string Name { get; set; }

        [MaxLength(32)]
        public string Email { get; set; }
    }
}
