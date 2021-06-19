using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books_Api.dbAccess.dto
{
    public class booksDto
    {
        public int isbn { get; set; }
        public int editorials { get; set; }
        public string tittle { get; set; }
        public string synopsis { get; set; }
        public string n_pages { get; set; }
    }
}
