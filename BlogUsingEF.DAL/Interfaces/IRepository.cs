using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogUsingEF.DAL.Interfaces
{
   public interface IRepository<T> where T : class
    {
        //Main methods for work with db.
        IEnumerable<T> GetList(); 
        T GetById(int id); 
        void Create(T item); 
        void Update(T item); 
        void Delete(int id);
        void Save();  
    }
}