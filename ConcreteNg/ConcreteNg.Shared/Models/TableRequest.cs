using ConcreteNg.Shared.Enums;
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
        public bool IsAscending { get; set; }
        public IEnumerable<TableColumnFilter> Filters { get; set; }

    }

    public class TableColumnFilter
    {
        public ProjectFilterColumnsEnum ColumnName { get; set; }
        public string FilterQuery { get; set; }

    }
}
