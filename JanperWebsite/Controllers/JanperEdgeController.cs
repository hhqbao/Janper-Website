using JanperWebsite.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace JanperWebsite.Controllers
{
    public class JanperEdgeController : Controller
    {
        public ActionResult Index()
        {
            var folderNames = Directory.GetDirectories(Server.MapPath("~/Images/JanperEdge")).Select(x =>
            {
                var dirInfo = new DirectoryInfo(x);

                return dirInfo.Name;
            });

            var imageSections = folderNames.Select(folder => new ImageSection { Title = folder, ImageUrls = ImageUrls(folder) }).ToList();

            return View(imageSections);
        }

        private IEnumerable<string> ImageUrls(string folder)
        {
            return Directory.EnumerateFiles(Server.MapPath($"~/Images/JanperEdge/{folder}")).Select(fn => $"~/Images/JanperEdge/{folder}/" + Path.GetFileName(fn));
        }
    }
}