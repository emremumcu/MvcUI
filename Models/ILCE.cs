using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcUI.Models
{
    public class JsonRootILCE
    {
        public List<ILCE> ilceler { get; set; }
    }
    public class ILCE
    {
        public string ilkodu { get; set; }
        public string iladi { get; set; }
        public string ilcekodu { get; set; }
        public string ilceadi { get; set; }
    }
}
