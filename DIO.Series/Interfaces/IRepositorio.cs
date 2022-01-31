using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T ReturnById(int id);        
        void Insert(T entidade);        
        void Del(int id);        
        void Update(int id, T entidade);
        int NextId();
    }
}