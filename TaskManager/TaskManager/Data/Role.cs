using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Data
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public string RoleID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
