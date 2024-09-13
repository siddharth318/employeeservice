
using TaskManagementAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace TaskManagementAPI.Services
{
    public class TaskManagementServices
    {


        //public TaskManagementServices() { }

        TaskManagementContext context = new TaskManagementContext();
        public void AddTaskManagement(TaskManagement r)
        {
            context.trans.Add(r);
            context.SaveChanges();//establish connection and sent sql insert command
        }
        public async Task<List<TaskManagement>> GetAllTaskManagement()
        {
            //return context.trans.FromSql($"select * from Transaction").ToList();
            List<TaskManagement> result = null;
            result = await context.trans.ToListAsync();
            return result;
        }
        public TaskManagement GetById(int id)
        {
            return context.trans.Where(s => s.TaskId == id).FirstOrDefault();
            //
        }
        public bool UpdateTaskManagement(int id, TaskManagement r)
        {
            //var result = context.Database.ExecuteSqlRaw($"update restaurants  set name={r.Name},Location={r.Location} where id={r.Id}");
            //or 
            var data = context.trans.Where(s => s.TaskId == id).FirstOrDefault();
            if (data != null)
            {
                data.TaskId = r.TaskId;
                data.Title = r.Title;
                data.Description = r.Description;
                data.AssignBy = r.AssignBy;
                data.AssignDate = r.AssignDate;
                data.Deadline = r.Deadline;
                data.Status = r.Status; 


            }
            context.SaveChanges();
            return true;
        }
        public bool DeleteTaskManagement(int id)
        {
            // var result = context.Database.ExecuteSql($"delete from restaurants where id={id}");
            //or
            var result = context.trans.Where(s => s.TaskId == id).FirstOrDefault();
            context.trans.Remove(result);
            context.SaveChanges();
            return true;
        }
    }
}
