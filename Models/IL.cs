using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcUI.Models
{
    public class JsonRootIL
    {
        public List<IL> iller { get; set; }
    }

    public class IL
    {
        public string ilkodu { get; set; }
        public string iladi { get; set; }
    }
}
