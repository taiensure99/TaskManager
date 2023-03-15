using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Enum
{
    public enum RoleEnum
    {
        [Display(Name = "Admin")]
        Admin = 1,
        [Display(Name = "Staff")]
        Staff = 2,
    }
}
