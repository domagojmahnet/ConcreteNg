using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Shared.Models
{
    public class TableRequest
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }

    }
}
