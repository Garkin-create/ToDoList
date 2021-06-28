namespace ToDoList.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ToDoList.Data;
    using ToDoList.Data.Model;

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ListItemController:Controller
    {
        private readonly IListItemRepository listItemRepository;
        private readonly IToDoListRepository toDoListRepository;

        public ListItemController(IListItemRepository listItemRepository, IToDoListRepository toDoListRepository)
        {
            this.listItemRepository =listItemRepository;
            this.toDoListRepository = toDoListRepository;
        }

        // GET: ListItem/Get
        [HttpGet]        
        public IEnumerable<ListItem> Get()
        {         
            return this.listItemRepository.GetAll().ToArray();
        }

        // GET: ListItem/GetList/{id}
        [HttpGet("{id}")]
        public IEnumerable<ListItem> GetList(int? id)
        {
           
            if (id == null)
            {
                return null;
            }
            var listItem = listItemRepository.GetListById(id.Value);
            if (listItem == null)
            {
                return null;
            }
            return listItem;
        }


        // GET: ListItem/Details/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var toDoList = await this.listItemRepository.GetByIdAsync(id.Value);

            if (toDoList == null)
            {
                return NotFound();
            }
            return Ok(toDoList);
        }

        
        // POST: ListItem/Create/
        [HttpPost]        
        public async Task<IActionResult> Create(ListItem listItem)
        {
             if (ModelState.IsValid)
             {
                await this.listItemRepository.CreateAsync(listItem);
                return Ok();
             }
             
             return NotFound();
        }

        // POST: ListItem/Edit/
        [HttpPost]        
        public async Task<IActionResult> Edit(ListItem listItem)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await this.listItemRepository.UpdateAsync(listItem);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.listItemRepository.ExistAsync(listItem.Id))
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
        // GET: ListItem/Delete/{id}
        [HttpGet("{id}")]        
        public async Task<IActionResult> Delete(int id)
        {
            
            var listItem = await this.listItemRepository.GetByIdAsync(id);
            
            await this.listItemRepository.DeleteAsync(listItem);
            return Ok();
        }
    }
    
}