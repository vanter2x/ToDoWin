namespace ToDoA.Data.Entity
{
    public class Memento: IEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}