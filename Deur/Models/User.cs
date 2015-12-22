using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deur.Models
{
    class User
    {
        public int Id;
        public bool Tag;
        public int? TagCode;

        public User()
        {

        }

        public User(int id, bool tag, int? tagcode)
        {
            this.Id = id;
            this.Tag = tag;
            this.TagCode = tagcode;
        }
    }
}
