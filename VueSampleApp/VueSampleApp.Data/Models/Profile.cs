using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VueSampleApp.Data.Models
{
    [Table("profiles")]
    public class Profile
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("department_id")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
