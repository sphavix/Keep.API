using Keep.DataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keep.DataService.Repository
{
    public interface ILinkRepository
    {
        List<Link> GetLinks();
        Link GetLinkById(int id);
        void AddLink(Link link);
        void UpdateLink(Link model);
        void DeleteLink(int id);
        
    }
}
