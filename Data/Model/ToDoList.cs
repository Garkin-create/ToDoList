namespace ToDoList.Data.Model{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
     
    public class ToDoList : IEntity
    {
        [Key]
        public int Id { get; set; }        
        public string Name { get; set; }
        public virtual ICollection<ListItem> ListItems { get; set; }        
    }
}