using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoProjet3._1.Models;

namespace TodoProjet3._1.Controllers
{
    public class TachesController : Controller
    {
        [HttpGet]
        public ActionResult Task()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Tache tache)
        {
            DBConnection.AjoutTache(tache);
            return RedirectToAction("Task");
        }
    }
}