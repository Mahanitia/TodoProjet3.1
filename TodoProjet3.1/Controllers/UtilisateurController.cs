using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoProjet3._1.Models;

namespace TodoProjet3._1.Controllers
{
    public class UtilisateurController : Controller
    {
        // GET: Utilisateur
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Inscription(Utilisateur utilisateur)
        {
            DBConnection.AjoutUtilisateur(utilisateur);
            return RedirectToAction("Index");
        }
        public ActionResult Login(Utilisateur utilisateur)
        {
            if (DBConnection.VerifierUtilisateur(utilisateur))
            {
                return RedirectToRoute("Tache");
            }
            else
            {
                return RedirectToRoute("Index");
            }

        }
        // GET: Utilisateur/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}