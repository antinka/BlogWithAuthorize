using System.Collections.Generic;
using BlogUsingEF.BLL.DTO;
using BlogUsingEF.BLL.Interfaces;
using BlogUsingEF.DAL.Interfaces;
using AutoMapper;
using BlogUsingEF.DAL.Entities;

namespace BlogUsingEF.BLL.Services
{
    public class TagServices : ITagServices
    {
    
        IUnitOfWork Database { get; set; }
        public TagServices(IUnitOfWork uow)
        {
            Database = uow;
        }
        //Return all tags from db.
        public IEnumerable<TagDTO> GetTags()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Tag, TagDTO>());
            IMapper mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<Tag>, List<TagDTO>>(Database.Tags.GetList());
        }
        // Add new tags to db.
        public void AddNewTag(TagDTO tagDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TagDTO, Tag>());
            IMapper mapper = config.CreateMapper();
            Database.Tags.Create(mapper.Map<TagDTO, Tag>(tagDTO));
            Database.Tags.Save();
        }
        //Delete tags from db.
        public void DeleteTag(int id)
        {
            Tag tag = Database.Tags.GetById(id);
            if (tag != null)
            {
                Database.Tags.Delete(id);
                Database.Tags.Save();
            }
        }
        // Return tags by send id.
        public TagDTO GetTagById(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Tag, TagDTO>());
            IMapper mapper = config.CreateMapper();
            TagDTO tagDTO = mapper.Map<Tag, TagDTO>(Database.Tags.GetById(id));
            return tagDTO;
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
