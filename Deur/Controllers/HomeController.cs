using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Deur.Models;

namespace Deur.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository = new InMemoryRepository();

        List<Door> doorList;

        [HttpGet]
        public ActionResult Index()
        {
            if (Session["id"] == null)
            {
                User user = repository.DefineUser(1);
                Session["id"] = user.Id;
                Session["tag"] = user.Tag;
                Session["tagcode"] = user.TagCode;
            }               
            List<Door> doorList = (List<Door>)Session["doorList"];
            List<string> historyList = (List<string>)Session["historyList"];
            IndexView indexview = new IndexView();
            indexview.ViewLists = doorList;
            indexview.ViewHistory = historyList;
            return View(indexview);
        }

        [HttpGet]
        public ActionResult AddDoors()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DefineUser(int id)
        {
            User user = repository.DefineUser(id);
            Session["id"] = user.Id;
            Session["tag"] = user.Tag;
            Session["tagcode"] = user.TagCode;
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult OpenDoor(int id)
        {
            List<Door> doorList = (List<Door>)Session["doorList"];
            bool doorBefore = doorList[id].Open;
            List<string> historyList = (List<string>)Session["historyList"];
            repository.SetHistoryList(historyList);          
            bool tag = (Boolean)Session["tag"];
            int ?tagcode = (int?)Session["tagcode"];
            
            Session["doorList"] = repository.OpenDoor(id, doorList, tag, tagcode);  
            Session["historyList"] = repository.GetHistory();

            List<Door> doorlist = (List<Door>)Session["doorList"];
            bool doorAfter = doorlist[id].Open;
            if (doorBefore != doorAfter) {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }         
        }

        [HttpPost]
        public ActionResult AddDoors(string naam)
        {
            if (Session["doorList"] != null)
            {
                repository.SetDoorList((List<Door>)Session["doorList"]);
            }
            repository.AddDoor(naam);
            Session["doorList"] = repository.GetAllDoors();
            return RedirectToAction("Index", "Home");
        }



    }
}
