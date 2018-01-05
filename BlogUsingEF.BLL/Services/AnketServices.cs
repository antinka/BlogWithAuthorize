using BlogUsingEF.BLL.Interfaces;
using BlogUsingEF.DAL.Entities;
using BlogUsingEF.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogUsingEF.BLL.Services
{
    public class AnketServices : IAnketServices
    {
        IUnitOfWork Database { get; set; }
        public AnketServices(IUnitOfWork uow)
        {
            Database = uow;
        }
        // save new anket in db
        public void AddNewAnket(string Name, string Gender, string[] Operator, string UseCodeOperatop)
        {
            string oper = "";
            foreach (var s in Operator)
            {
                oper += s;
                oper += " , ";
            }
            Anket anket = new Anket();
            anket.Gender = Gender;
            anket.Name = Name;
            anket.Operator = oper;
            anket.UseCodeOperatop = UseCodeOperatop;
            Database.Ankets.Create(anket);
            Database.Ankets.Save();
        }
    }
}
