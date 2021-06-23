namespace ToDoList.Data{
    using ToDoList.Data.Model;

    public class ToDoListRepository:GenericRepository<ToDoList>, IToDoListRepository
    {
        public ToDoListRepository(ToDoListContext context):base(context)
        {
            
        }
    }
    
}