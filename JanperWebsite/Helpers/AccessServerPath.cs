using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JanperWebsite.PhysicalAccessPaths
{
    public class AccessServerPath
    {
        public static string FilePath()
        {
            string path = string.Empty;
            path = System.Web.HttpContext.Current.Server.MapPath("~/XML/");
            return path;
        }
    }
}