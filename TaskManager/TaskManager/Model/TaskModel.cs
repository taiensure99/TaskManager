using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Model
{
    public class TaskModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public string Decription { get; set; }
        public string Note { get; set; }
        public int Percent { get; set; }
        public string Users { get; set; }
    }
}
