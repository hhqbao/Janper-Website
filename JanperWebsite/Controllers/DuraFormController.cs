using JanperWebsite.Models;
using JanperWebsite.PhysicalAccessPaths;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Xml.Linq;

namespace JanperWebsite.Controllers
{
    public class DuraFormController : Controller
    {
        // GET: JanperAcrylic
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SeriesOne()
        {
            return PartialView();
        }
        public ActionResult SeriesTwo()
        {
            return PartialView();
        }
        public ActionResult SeriesThree()
        {
            return PartialView();
        }
        public ActionResult SeriesFour()
        {
            return PartialView();
        }
        public ActionResult SeriesFive()
        {
            return PartialView();
        }
        public ActionResult Colours()
        {
            try
            {
                var folderNames = Directory.GetDirectories(Server.MapPath("~/Images/Duraform/Colours")).Select(x =>
                {
                    var dirInfo = new DirectoryInfo(x);

                    return dirInfo.Name;
                });

                var imageSections = folderNames
                    .Select(folder => new ImageSection { Title = folder, ImageUrls = ImageUrls(folder) }).ToList();

                return View("~/Views/DuraForm/Colours/Index.cshtml", imageSections);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
        public ActionResult Options()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult GenerateDoor(string doorName, string sender)
        {
            String doorPath = AccessServerPath.FilePath() + "DuraFormDoors.xml";
            XDocument doorObject = XDocument.Load(doorPath);

            Model_Door door = new Model_Door();
            door.Sender = sender;
            foreach (var node in doorObject.Descendants("Door"))
            {
                if (node.Element("name").Value.ToUpper() == doorName.ToUpper())
                {
                    int counter = 0;
                    door.Images = new List<string> { "", "", "", "", "" };
                    door.Name = doorName;
                    door.Series = node.Element("series").Value;
                    door.Round = node.Element("round").Value;
                    door.Profile = node.Element("profile").Value;
                    var images = node.Element("images").Descendants("image");

                    //for (int i = 0; i < node.Descendants("image").Count(); i++)
                    //{
                    //    door.Images[i] = node.Descendants("image").ElementAt(i).ToString();
                    //}

                    foreach (var image in images)
                    {
                        door.Images.Insert(counter, image.Value);
                        counter++;
                    }


                    return View("~/Views/DuraForm/Door.cshtml", door); ;
                }
            }
            return null;

        }

        private IEnumerable<string> ImageUrls(string folder)
        {
            return Directory.EnumerateFiles(Server.MapPath($"~/Images/Duraform/Colours/{folder}")).Select(fn => $"~/Images/Duraform/Colours/{folder}/" + Path.GetFileName(fn));
        }
    }
}

