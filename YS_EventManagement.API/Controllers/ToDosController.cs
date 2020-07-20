using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YS_EventManagement.Business.Abstract;
using YS_EventManagement.Business.Concrete;
using YS_EventManagement.Entities;

namespace YS_EventManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDosController : ControllerBase
    {

        private IToDoService _toDoService;

        public ToDosController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        /// <summary>
        /// Get All ToDO's
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllToDos()
        {
            var todos = await _toDoService.GetAllToDos();
            return Ok(todos); //200 + data  
        }

        /// <summary>
        /// Get ToDo's By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]  // 
        public async Task<IActionResult> GetToDoById(int id)
        {
            var todo = await _toDoService.GetToDoById(id);
            if (todo!= null)
            {
                return Ok(todo);//200 + data
            }
            return NotFound(); //400
        }


        /// <summary>
        /// Get ToDo's By Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{name}")]  // 
        public async Task<IActionResult> GetToDoByName(string name)
        {
            var todo = await _toDoService.GetToDoByName(name);
            if (todo != null)
            {
                return Ok(todo);//200 + data
            }
            return NotFound(); //400
        }

        /// <summary>
        /// Get ToDo's By Id and Name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]  // 
        public async Task<IActionResult> GetToDoByIdAndName(int id,  string name)
        {
            
            return  Ok(); // This API's busines and Data Access InterFace's and Class's did not code yet...
        }


        /// <summary>
        /// Create an ToDo
        /// </summary>
        /// <param name="todo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateToDo([FromBody]ToDo todo)
        {
            var createdToDo = await _toDoService.CreateToDo(todo);
            

            if (createdToDo != null)
            {
                return Ok(createdToDo);//200 + data
            }
            return NotFound(); //400
        }

        /// <summary>
        /// Updadate the ToDo's
        /// </summary>
        /// <param name="todo"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateToDo([FromBody] ToDo todo)
        {
            var chnagedToDo = await _toDoService.UpdateToDo(todo);
            if (chnagedToDo != null)
            {
                return Ok(chnagedToDo);//200 + data
            }
            return NotFound(); //400
        }

        /// <summary>
        /// Delete the ToDO
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteToDo(int id)
        {
            var changedToDo = await _toDoService.GetToDoById(id);

            if (changedToDo  != null)
            {
                await _toDoService.DeleteToDo(id);
                return Ok();//200 + data
            }
            return NotFound(); //400
        }





    }

}
