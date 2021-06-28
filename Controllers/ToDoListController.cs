namespace ToDoList.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ToDoList.Data;
    using ToDoList.Data.Model;

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ToDoListController:Controller
    {
        private readonly IToDoListRepository toDoListRepository;
        private readonly IListItemRepository listItemRepository;
        public ToDoListController(IToDoListRepository toDoListRepository, IListItemRepository listItemRepository)
        {
            this.toDoListRepository = toDoListRepository;            
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
                return Ok();
             }
             
             return NotFound();
        }

        // POST: ToDoList/Edit/
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
                        return Ok();
                    }
                }
                return Ok();
            }

            return NotFound();
        }
        // GET: ToDoList/Delete/{id}
        [HttpGet("{id}")]         
        public async Task<IActionResult> Delete(int id)
        {
            var toDoList = await this.toDoListRepository.GetByIdAsync(id);
            
            await this.toDoListRepository.DeleteAsync(toDoList);

            
            return Ok();
        }
    }
    
}