using Keep.DataService.Models;
using Keep.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Keep.Web.Controllers
{
    public class LinksController : Controller
    {
        // GET: Links
        public ActionResult Index()
        {
            IEnumerable<LinkViewModel> links;

            HttpResponseMessage response = GlobalVariables.client.GetAsync("Links").Result;
            links = response.Content.ReadAsAsync<IEnumerable<LinkViewModel>>().Result;
            return View(links);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if(id == 0)
            {
                return View(new LinkViewModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.client.GetAsync("Links/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<LinkViewModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(LinkViewModel model)
        {
            HttpResponseMessage response = GlobalVariables.client.PostAsJsonAsync("Links", model).Result;
            TempData["SuccessMessage"] = "Link Saved Successfully";
            return RedirectToAction("Index");
        }
    }
}