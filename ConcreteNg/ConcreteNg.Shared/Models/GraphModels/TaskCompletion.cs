using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Shared.Models.GraphModels
{
    public class TaskCompletion
    {
        public int DesignatedTotal { get; set; }
        public IEnumerable<PieGrid> PieGrid { get; set; }

        public TaskCompletion(int designatedTotal, IEnumerable<PieGrid> pieGrid)
        {
            DesignatedTotal = designatedTotal;
            PieGrid = pieGrid;
        }
    }
}
