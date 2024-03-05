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
        public ActionResult TaskList()
        {
            return View(DBConnection.retrouverTaches(Session["username"].ToString()));
        }

        [HttpPost]
        public ActionResult Add(Tache tache)
        {
            DBConnection.AjoutTache(tache);
            return RedirectToRoute("Tache");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            DBConnection.SupprimerTache(id);
            return RedirectToAction("TaskList");
        }


    }
}