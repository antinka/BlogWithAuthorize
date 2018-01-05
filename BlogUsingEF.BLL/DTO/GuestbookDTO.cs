using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogUsingEF.BLL.DTO
{
    public class GuestbookDTO
    {
        public int Id { get; set; }
        public string NameAuthor { get; set; }
        public DateTime? DataPublish { get; set; }
        public string Text { get; set; }
    }
}
