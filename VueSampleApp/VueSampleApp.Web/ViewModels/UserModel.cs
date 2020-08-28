using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace VueSampleApp.Web.ViewModels
{
    public class UserModel
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int ProfileId { get; set; }
    }
}
