namespace ToDoList.Data{
    using System.Linq;
    using System.Threading.Tasks;
    using ToDoList.Data.Model;

    public class ListItemRepository:GenericRepository<ListItem>, IListItemRepository
    {
        private readonly ToDoListContext context;

        public ListItemRepository(ToDoListContext context):base(context)
        {
            this.context = context;
        }

         public IQueryable<ListItem> GetListById(int id)
    	{
    	    return this.context.ListItems.Where(l=>l.ToDoListId==id);
	    }

        public async Task DeleteAll(int id){
            this.context.ListItems.RemoveRange(GetListById(id));
            await SaveAllAsync();
        }
    }
    
}