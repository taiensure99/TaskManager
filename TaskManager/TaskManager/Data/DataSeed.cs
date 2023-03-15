using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Enum;
using TaskManager.Model;

namespace TaskManager.Data
{
    public static class DataSeed
    {
        public static void Initialize(MyDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Roles.Any())
            {
                var roles = new Role[]
                {
                new Role{RoleID ="Admin", Name = "Admintrator"},
                new Role{RoleID ="Staff", Name = "Nhân Viên"},

                };
                foreach (Role s in roles)
                {
                    context.Roles.Add(s);
                }
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                var users = new User[]
                {
                    new User{UserName ="User1", Password = "123", Name = "Nhân viên 1", Role = "Staff"},
                    new User{UserName ="User2", Password = "123",Name = "Nhân viên 2", Role = "Admin"},
                    new User{UserName ="User3", Password = "123",Name = "Nhân viên 3", Role = "Staff"},

                 };
                foreach (User s in users)
                {
                    context.Users.Add(s);
                }
                context.SaveChanges();
            }


            if (!context.Tasks.Any())
            {
                var tasks = new Task[]
                {
                    new Task{ Name ="Task1",Status = (int)StatusEnum.NotYet, Decription="Task công viêc 1", Note="", Percent=0,Users="User1" },
                    new Task{ Name ="Task2",Status = (int)StatusEnum.NotYet, Decription="Task công viêc 2", Note="", Percent=0,Users="User3" },
                    new Task{ Name ="Task3",Status = (int)StatusEnum.NotYet, Decription="Task công viêc 3", Note="", Percent=0,Users="User1,User3" },
                    new Task{ Name ="Task4",Status = (int)StatusEnum.Doing, Decription="Task công viêc 4", Note="", Percent=0,Users="User1,User3" },
                    new Task{ Name ="Task5",Status = (int)StatusEnum.Finish, Decription="Task công viêc 5", Note="", Percent=0,Users="User3" },
                };

                foreach (Task s in tasks)
                {
                    context.Tasks.Add(s);
                }
                context.SaveChanges();
            }

        }
    }

}
