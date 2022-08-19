using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Shared.Models.GraphModels
{
    public class GraphData
    {
        public IEnumerable<TaskCompletion> TaskCompletions { get; set; }
        public IEnumerable<PieGrid> GaugeData { get; set; }

        public GraphData(IEnumerable<TaskCompletion> taskCompletions, IEnumerable<PieGrid> gaugeData)
        {
            TaskCompletions = taskCompletions;
            GaugeData = gaugeData;
        }
    }
}
