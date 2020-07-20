using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using YS_EventManagement.DataAccess.Abstract;
using YS_EventManagement.Entities;

namespace YS_EventManagement.DataAccess.Concrate
{
    public class ToDoRepository : IToDoRepository
    {
        public async Task<ToDo> CreateToDo(ToDo todo)
        {
            using (var toDoDbContext = new ToDoDbContext())
            {
                toDoDbContext.ToDos.Add(todo);
                await toDoDbContext.SaveChangesAsync();
                return todo;
            }
        }

        public async Task DeleteToDo(int id)
        {
            using (var toDoDbContext = new ToDoDbContext())
            {
                toDoDbContext.ToDos.Remove(await GetToDoById(id));
                await toDoDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<ToDo>> GetAllToDos()
        {
            using (var toDoDbContext = new ToDoDbContext())
            {
                return await toDoDbContext.ToDos.ToListAsync();
            }
        }

        public async Task<ToDo> GetToDoById(int id)
        {
            using (var toDoDbContext = new ToDoDbContext())
            {   
                return await toDoDbContext.ToDos.FindAsync(id);
            }
        }
        
        public async Task<ToDo> GetToDoByName(string name)
        {
            using (var toDoDbContext = new ToDoDbContext())
            {
                return await toDoDbContext.ToDos.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
            }
        }

        public async Task<ToDo> UpdateToDo(ToDo todo)
        {
            using (var toDoDbContext = new ToDoDbContext())
            {
                toDoDbContext.ToDos.Update(todo);
                await toDoDbContext.SaveChangesAsync();
                return todo;
            }
        }
    }
}











