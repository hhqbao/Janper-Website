using JanperWebsite.PhysicalAccessPaths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using JanperWebsite.Models;
using System.Text.RegularExpressions;

namespace JanperWebsite.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SiteSearch(string searchString)
        {
            String Db = AccessServerPath.FilePath() + "SearchTerms.xml";
            XDocument searchObject = XDocument.Load(Db);
            searchString = Regex.Replace(searchString, @"\t|\n|\r", "");
            Model_Results results = new Model_Results();
            results.Tag = searchString;
            foreach (var node in searchObject.Descendants("Result"))
            {
                foreach(var tagsNode in node.Descendants("Tags"))
                {
                    foreach (var tagnode in tagsNode.Descendants("tag"))
                    {
                        string cleaned = Regex.Replace(tagnode.Value, @"\t|\n|\r", "");
                        if (cleaned.Trim().ToUpper().Contains(" " + searchString.ToUpper() + " "))
                        {
                            Model_Result result = new Model_Result();
                            String tagOutput = "";
                            List<String> upperCleaned = cleaned.Trim().Split(' ').ToList();
                            foreach (String s in upperCleaned)
                            {
                                tagOutput = tagOutput + " " + (char.ToUpper(s[0]) + s.Substring(1));
                            }
                            result.Link = tagnode.Parent.Parent.Element("link").Value.Trim();
                            result.Page = tagnode.Parent.Parent.Element("page").Value.Trim() + " - " + tagOutput;
                            //result.Page = tagnode.Parent.Parent.Element("page").Value.Trim();
                            results.Results.Add(result);
                            continue;
                        }
                        else if (!cleaned.Trim().Contains(' ') & cleaned.Trim().ToUpper() == searchString.ToUpper())
                        {
                            Model_Result result = new Model_Result();
                            String tagOutput = "";
                            List<String> upperCleaned = cleaned.Trim().Split(' ').ToList();
                            foreach (String s in upperCleaned)
                            {
                                tagOutput = tagOutput + " " + (char.ToUpper(s[0]) + s.Substring(1));
                            }
                            result.Link = tagnode.Parent.Parent.Element("link").Value.Trim();
                            result.Page = tagnode.Parent.Parent.Element("page").Value.Trim() + " - " + tagOutput;
                            //result.Page = tagnode.Parent.Parent.Element("page").Value.Trim();
                            results.Results.Add(result);
                            continue;
                        }
                        else if (cleaned.Trim().ToUpper().Contains(searchString.ToUpper() + " "))
                        {
                            Model_Result result = new Model_Result();
                            String tagOutput = "";
                            List<String> upperCleaned = cleaned.Trim().Split(' ').ToList();
                            foreach (String s in upperCleaned)
                            {
                                tagOutput = tagOutput + " " + (char.ToUpper(s[0]) + s.Substring(1));
                            }
                            result.Link = tagnode.Parent.Parent.Element("link").Value.Trim();
                            result.Page = tagnode.Parent.Parent.Element("page").Value.Trim() + " - " + tagOutput;
                            //result.Page = tagnode.Parent.Parent.Element("page").Value.Trim();
                            results.Results.Add(result);
                            continue;
                        }
                        else if (cleaned.Trim().ToUpper().Contains(" " + searchString.ToUpper()))
                        {
                            Model_Result result = new Model_Result();
                            String tagOutput = "";
                            List<String> upperCleaned = cleaned.Trim().Split(' ').ToList();
                            foreach (String s in upperCleaned)
                            {
                                tagOutput = tagOutput + " " + (char.ToUpper(s[0]) + s.Substring(1));
                            }
                            result.Link = tagnode.Parent.Parent.Element("link").Value.Trim();
                            result.Page = tagnode.Parent.Parent.Element("page").Value.Trim() + " - " + tagOutput;
                            //result.Page = tagnode.Parent.Parent.Element("page").Value.Trim();
                            results.Results.Add(result);
                            continue;
                        }
                    }
                }

            }
            return View("~/Views/Search/Index.cshtml", results);
        }
    }
}