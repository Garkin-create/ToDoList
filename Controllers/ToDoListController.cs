namespace ToDoList.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using ToDoList.Data;
    using ToDoList.Data.Model;

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ToDoListController:Controller
    {
        private readonly IToDoListRepository toDoListRepository;

        public ToDoListController(IToDoListRepository toDoListRepository)
        {
            this.toDoListRepository = toDoListRepository;
        }

        public ToDoListController()
        {
        }

        // GET: ToDoList/Get
        [HttpGet]        
        public IEnumerable<ToDoList> Get()
        {         
            return toDoListRepository.GetAll().ToArray();
        }

        // GET: ToDoList/Details/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var toDoList = await this.toDoListRepository.GetByIdAsync(id.Value);

            if (toDoList == null)
            {
                return NotFound();
            }
            return Ok(toDoList);
        }

        // POST: ToDoList/Create/{toDoList}
        [HttpPost]        
        public async Task<IActionResult> Create(ToDoList toDoList)
        {
             if (ModelState.IsValid)
             {
                await this.toDoListRepository.CreateAsync(toDoList);                
                return Ok("Created");
             }
             
             return NotFound();
        }

        // POST: ToDoList/Edit/{toDoList}
        [HttpPost]        
        public async Task<IActionResult> Edit(ToDoList toDoList)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await this.toDoListRepository.UpdateAsync(toDoList);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.toDoListRepository.ExistAsync(toDoList.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        return Ok("Error");
                    }
                }
                return Ok("Modified");
            }

            return NotFound();
        }
        // POST: ToDoList/Delete/{id}
        [HttpPost]        
        public async Task<IActionResult> Delete(int id)
        {
            var toDoList = await this.toDoListRepository.GetByIdAsync(id);
            await this.toDoListRepository.DeleteAsync(toDoList);
            return Ok("Deleted");
        }
    }
    
}