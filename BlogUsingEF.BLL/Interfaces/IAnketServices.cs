using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogUsingEF.BLL.Interfaces
{
    public interface IAnketServices
    {
        void AddNewAnket(string Name, string Gender, string[] Operator, string UseCodeOperatop);
    }
}
