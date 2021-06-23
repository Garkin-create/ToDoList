namespace ToDoList.Data{
    using ToDoList.Data.Model;

    public class ListItemRepository:GenericRepository<ListItem>, IListItemRepository
    {
        public ListItemRepository(ToDoListContext context):base(context)
        {
            
        }
    }
    
}