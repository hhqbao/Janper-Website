using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace JanperWebsite.Controllers
{
    public class JanperEdgeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Woodgrain = Directory.EnumerateFiles(Server.MapPath("~/Images/JanperEdge/Woodgrain")).Select(fn => ("~/Images/JanperEdge/Woodgrain/" + Path.GetFileName(fn)));

            ViewBag.Matt = Directory.EnumerateFiles(Server.MapPath("~/Images/JanperEdge/Matt")).Select(fn => ("~/Images/JanperEdge/Matt/" + Path.GetFileName(fn)));

            return View();
        }
    }
}