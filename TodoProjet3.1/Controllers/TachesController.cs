using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.WebPages;
using System.Xml.Linq;
using TodoProjet3._1.Models;

namespace TodoProjet3._1.Controllers
{
    public class TachesController : Controller
    {
        [HttpGet]
        public ActionResult TaskList()
        {
            if (Session["username"] == null)
            {
                return RedirectToRoute("Accueil");
            }
            else
            {
                return View(DBConnection.RetrouverTaches(Session["username"].ToString()));
            }

        }

        [HttpPost]
        public ActionResult Add(FormCollection form,Utilisateur utilisateur)
        { 
            var tache = new Tache(Session["username"].ToString(), form["tachenom"], form["state"]==null?false:true);
            DBConnection.AjoutTache(tache);
            return RedirectToRoute("Tache");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            DBConnection.SupprimerTache(id);
            return RedirectToAction("TaskList");
        }

        [HttpPost]
        public ActionResult ModifyTask(FormCollection form)
        {
            var tache = new Tache(Session["username"].ToString(), form["tachenoms"], form["states"] == null ? false : true);
            DBConnection.ModifierTache(int.Parse(form["idTache"]), tache);
            return RedirectToAction("TaskList");
        }       
    }
}