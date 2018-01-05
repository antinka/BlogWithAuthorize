using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogUsingEF.DAL.Entities
{
    public class Anket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Operator { get; set; }
        public string UseCodeOperatop { get; set; }
    }
}
