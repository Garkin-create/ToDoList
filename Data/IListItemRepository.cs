namespace ToDoList.Data
{
    using System.Linq;
    using System.Threading.Tasks;
    using ToDoList.Data.Model;
    
    public interface IListItemRepository:IGenericRepository<ListItem>
    {
        IQueryable<ListItem> GetListById(int id);

        Task DeleteAll(int id);
    }

    

}