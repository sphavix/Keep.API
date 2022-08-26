using Keep.DataService.Context;
using Keep.DataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keep.DataService.Repository
{
    public class LinkRepository: ILinkRepository
    {
        private readonly LinkContext _contxt;
        public LinkRepository(LinkContext contxt)
        {
            _contxt = contxt;
        }

        public List<Link> GetLinks()
        {
            return _contxt.Links.ToList();
        }

        public Link GetLinkById(int id)
        {
            return _contxt.Links.FirstOrDefault(x => x.Id == id);
        }

        public void AddLink(Link model)
        {
            _contxt.Links.Add(model);
            _contxt.SaveChanges();
        }

        public void UpdateLink(int id)
        {
            //var link = _contxt.Links.FirstOrDefault(x => x.Id == model.Id);
            Link objlink = _contxt.Links.FirstOrDefault(p => p.Id == id);
            if(objlink != null)
            {
            //    objlink.Id = model.Id;
            //    objlink.LinkName = model.LinkName;
            //    objlink.Description = model.Description;
            //    objlink.LinkUrl = model.LinkUrl;

                var entiy = _contxt.Entry(objlink);
                entiy.State = System.Data.Entity.EntityState.Modified;
                _contxt.SaveChanges();
            }
        }

        public void DeleteLink(int id)
        {
            var link = _contxt.Links.FirstOrDefault(x => x.Id == id);
            if (link != null)
            {
                _contxt.Links.Remove(link);
                _contxt.SaveChanges();
            }
        }
    }
}
