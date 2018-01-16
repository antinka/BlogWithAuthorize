using BlogUsingEF.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogUsingEF.BLL.Interfaces
{
   public interface ITagServices
    {
        IEnumerable<TagDTO> GetTags();
        TagDTO GetTagById(int id);
        void AddNewTag(TagDTO tagDTO);
        void DeleteTag(int id);
        void Dispose();
    }
}
