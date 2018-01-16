using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogUsingEF.BLL.DTO
{
   public class TagDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
