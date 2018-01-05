using BlogUsingEF.BLL.Interfaces;
using BlogUsingEF.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogUsingEF.BLL.DTO;
using AutoMapper;
using BlogUsingEF.DAL.Entities;

namespace BlogUsingEF.BLL.Services
{
    public class GuestbookServices : IGuestbookServices
    {
        IUnitOfWork Database { get; set; }
        public GuestbookServices(IUnitOfWork uow)
        {
            Database = uow;
        }
        // return all reviews which has in db
        public IEnumerable<GuestbookDTO> GetGuestbook()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Guestbook, GuestbookDTO>());
            IMapper mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<Guestbook>, List<GuestbookDTO>>(Database.Guestbooks.GetList());
        }
        // add new review
        public void AddToGuestbook(GuestbookDTO guestbookDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<GuestbookDTO, Guestbook>());
            IMapper mapper = config.CreateMapper();
            guestbookDTO.DataPublish = DateTime.Now;
            Database.Guestbooks.Create(mapper.Map<GuestbookDTO, Guestbook>(guestbookDTO));
            Database.Guestbooks.Save();
        }
    }
}
