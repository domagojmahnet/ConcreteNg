using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Shared.Models
{
    public class TableResponse
    {
        public IEnumerable<object> Data { get; set; }
        public int TotalRows { get; set; }
    }
}
