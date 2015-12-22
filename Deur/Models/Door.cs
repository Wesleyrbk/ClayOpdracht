using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deur.Models
{
    public class Door
    {
        public string Name;
        public int Code;
        public bool Open;

        public Door()
        {

        }

        public Door(string name, int code, bool open)
        {
            this.Name = name;
            this.Code = code;
            this.Open = open;
        }
    }
}
