using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Data;
using TaskManager.Form;
using TaskManager.Model;
using TaskManager.Services;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class TaskController : ControllerBase
    {
        private readonly MyDbContext _context;

        public TaskController(MyDbContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var taskRepository = new TaskRepository(_context);
                return Ok(taskRepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("GetListCondition")]
        [HttpPost]
        public IActionResult GetListTaskByUser(SearchTaskForm data)
        {
            try
            {
                var taskRepository = new TaskRepository(_context);
                return Ok(taskRepository.GetListTaskByUser(data.UserName, data.Status));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("GetById")]
        [HttpGet]    
        public IActionResult GetById(int id)
        {
            var taskRepository = new TaskRepository(_context);
            var Loai = taskRepository.GetTaskByID(id);
            if (Loai != null)
            {
                return Ok(Loai);
            }
            else
            {
                return NotFound();
            }
        }

        //Them moi
        [Route("AddNew")]
        [HttpPost]
        public IActionResult AddNew(TaskModel data)
        {
            try
            {
                var taskRepository = new TaskRepository(_context);
                var rs = taskRepository.AddTask(data);
                //if (rs)
                //{
                //    return Ok("ok");
                //}
                return Ok(rs);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [Route("Update")]
        [HttpPut]
        public IActionResult Update(TaskModel data)
        {
            try
            {
                var taskRepository = new TaskRepository(_context);
                var rs = taskRepository.Update(data);
                //if (rs)
                //{
                //    return Ok("ok");
                //}
                return Ok(rs);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [Route("Delete")]
        [HttpDelete()]
        public IActionResult DeleteById(int id)
        {
            var taskRepository = new TaskRepository(_context);
            var rs = taskRepository.Delete(id);
            if (rs)
            {
                return Ok(rs);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
