using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YS_EventManagement.Business.Abstract;
using YS_EventManagement.DataAccess.Abstract;
using YS_EventManagement.DataAccess.Concrate;
using YS_EventManagement.Entities;

namespace YS_EventManagement.Business.Concrete
{
    public class ToDoManager : IToDoService
    {
        private IToDoRepository _toDoRepository;

        public ToDoManager(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public async Task<ToDo> CreateToDo(ToDo todo)     
        {
            return await _toDoRepository.CreateToDo(todo);
        }

        public async Task DeleteToDo(int id)
        {
            await _toDoRepository.DeleteToDo(id);
        }

        public async Task<List<ToDo>> GetAllToDos()
        {
            return await _toDoRepository.GetAllToDos();
        }

        public async Task<ToDo> GetToDoById(int id)
        {
            return await _toDoRepository.GetToDoById(id);
        }

        public async Task<ToDo> GetToDoByName(string name)
        {
            return await _toDoRepository.GetToDoByName(name);
        }

        public async Task<ToDo> UpdateToDo(ToDo todo)
        {
            return await _toDoRepository.UpdateToDo(todo);
        }
    }
}
