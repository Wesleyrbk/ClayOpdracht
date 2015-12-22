using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deur.Models
{
    public class IndexView
    {
        public List<Deur.Models.Door> ViewLists { get; set; }
        public List<string> ViewHistory { get; set; }
    }
}
