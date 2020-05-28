using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace JanperWebsite.Models
{
    public class Model_Door
    {
        public string Series { get; set; }

        public string Name { get; set; }

        public string Round { get; set; }

        public List<string> Images { get; set; }

        public string Profile { get; set; }

        public string Sender { get; set; }
    }
}