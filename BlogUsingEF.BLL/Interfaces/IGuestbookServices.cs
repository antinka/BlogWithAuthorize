using BlogUsingEF.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogUsingEF.BLL.Interfaces
{
     public interface IGuestbookServices
    {
        IEnumerable<GuestbookDTO> GetGuestbook();
       void AddToGuestbook(GuestbookDTO guestbookDTO);
    }
}
