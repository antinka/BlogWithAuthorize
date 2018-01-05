using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogUsingEF.DAL.Entities
{
    public class Guestbook
    {
        public int Id { get; set; }
        public string NameAuthor { get; set; }
        public DateTime DataPublish { get; set; }
        public string Text { get; set; }
    }
}
