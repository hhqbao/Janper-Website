using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JanperWebsite.Models
{
    public class Model_Result
    {
        public string Page { get; set; }

        public string Link { get; set; }
    }

    public class Model_Results
    {
        public string Tag { get; set; }
        public List<Model_Result> Results = new List<Model_Result>();
    }
}