using System.Collections.Generic;
using ToDoA.Data.Entity;

namespace ToDoA.Data.Database
{
    public interface IDataRepository<T> where T: IEntity
    {
        IEnumerable<T> GetAll();
        void AddMemo(T memento);
        void DeleteMemo(T memento);
        void UpdateMemo(T memento);
        T GetMemo(int id);
    }
}