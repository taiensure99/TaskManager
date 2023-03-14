using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Data
{
    [Table("User")]
    public class User
    {
        [Key]
        public string UserName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Passwork { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
