using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Data
{
    [Table("Task")]
    public class Task
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public int Status { get; set; }
        public string Users { get; set; }
        public string Decription { get; set; }
        [MaxLength(1000)]
        public string Note { get; set; }
        public int Percent { get; set; }
    }
}
