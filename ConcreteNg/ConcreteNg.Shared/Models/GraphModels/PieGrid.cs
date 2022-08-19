using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Shared.Models.GraphModels
{
    public class PieGrid
    {
        public string Name { get; set; }
        public float Value { get; set; }

        public PieGrid(string name, float value)
        {
            Name = name;
            Value = value;
        }
    }
}
