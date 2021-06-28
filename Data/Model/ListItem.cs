namespace ToDoList.Data.Model{    
    using System.ComponentModel.DataAnnotations;
    public class ListItem : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public int? ToDoListId { get; set; }
        public virtual ToDoList ToDoList { get; set; }
        
    }
}