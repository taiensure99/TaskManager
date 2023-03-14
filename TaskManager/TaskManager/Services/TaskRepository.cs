using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Data;
using TaskManager.Model;


namespace TaskManager.Services
{
    public class TaskRepository
    {
        private readonly MyDbContext _context;

        public TaskRepository(MyDbContext context)
        {
            _context = context;
        }

        public bool AddTask(TaskModel task)
        {
            var newDB = new Data.Task
            {
                Name = task.Name,
                Status = 1,
                Decription = task.Decription,
                Note = task.Note,
                Percent = 0,
                Users = task.Users
            };
            _context.Add(newDB);
            var rs = _context.SaveChanges();
            return rs > 0;
        }

        public bool Delete(int id)
        {
            var taskRemove = _context.Tasks.FirstOrDefault(f => f.ID == id);
            if (taskRemove != null)
            {
                _context.Remove(taskRemove);
                
            }
            return _context.SaveChanges() > 0;
        }

        public List<TaskModel> GetAll()
        {
            var list = _context.Tasks.Select(f => new TaskModel
            {
                ID=f.ID,
                Name = f.Name,
                Status = f.Status,
                Decription = f.Decription,
                Note = f.Note,
                Percent = f.Percent,
                Users = f.Users
            });
            return list.ToList();
        }

        public List<TaskModel> GetListTaskByUser(string userName, int status)
        {
            var user = _context.Users.FirstOrDefault(f => f.UserName == userName);
            var list = new List<TaskModel>();
            if (user.Role == "Staff")
            {
                if(status == 0)
                {
                    list = _context.Tasks.Where(f=>f.Users.Contains(user.UserName)).Select(f => new TaskModel
                    {
                        ID = f.ID,
                        Name = f.Name,
                        Status = f.Status,
                        Decription = f.Decription,
                        Note = f.Note,
                        Percent = f.Percent,
                        Users = f.Users
                    }).ToList();
                }
                else
                {
                    list = _context.Tasks.Where(f => f.Users.Contains(user.UserName) && f.Status == status).Select(f => new TaskModel
                    {
                        ID = f.ID,
                        Name = f.Name,
                        Status = f.Status,
                        Decription = f.Decription,
                        Note = f.Note,
                        Percent = f.Percent,
                        Users = f.Users
                    }).ToList();
                }
            }
            else
            {
                if (status == 0)
                {
                    list = GetAll();
                }
                else
                {
                    list = _context.Tasks.Where(f =>f.Status == status).Select(f => new TaskModel
                    {
                        ID = f.ID,
                        Name = f.Name,
                        Status = f.Status,
                        Decription = f.Decription,
                        Note = f.Note,
                        Percent = f.Percent,
                        Users = f.Users
                    }).ToList();
                }
            }

            return list;

        }

        public bool Update(TaskModel task)
        {
            var data = _context.Tasks.FirstOrDefault(f=>f.ID == task.ID);
            data.Name = task.Name;
            data.Status = task.Status;
            data.Decription = task.Decription;
            data.Note = task.Note;
            data.Percent = task.Percent;
            data.Users = task.Users;
           return _context.SaveChanges() > 0;
        }

        public TaskModel GetTaskByID(int id)
        {
            var data = _context.Tasks.FirstOrDefault(f => f.ID == id);
            if (data != null)
            {
                return new TaskModel
                {
                    ID = data.ID,
                    Name = data.Name,
                    Status = data.Status,
                    Decription = data.Decription,
                    Note = data.Note,
                    Percent = data.Percent,
                    Users = data.Users
                };
            }
            return null;
        }
    }
}
