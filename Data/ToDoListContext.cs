namespace ToDoList.Data
{    
    using Microsoft.EntityFrameworkCore;
    using ToDoList.Data.Model;

    public class ToDoListContext:DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=todoList.db");
        }

        public DbSet<ToDoList> ToDoListIds { get; set; } 
        public DbSet<ListItem> ListItems { get; set; } 


    }
    
}