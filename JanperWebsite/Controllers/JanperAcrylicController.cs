using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JanperWebsite.Controllers
{
    public class JanperAcrylicController : Controller
    {
        // GET: JanperAcrylic
        public ActionResult Index()
        {
            ViewBag.Images = Directory.EnumerateFiles(Server.MapPath("~/Images/JanperAcrylic/")).Select(fn => ("~/Images/JanperAcrylic/" + Path.GetFileName(fn)));

            return View();
        }
    }
}