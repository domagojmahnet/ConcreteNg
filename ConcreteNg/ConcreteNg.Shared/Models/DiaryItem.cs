using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Shared.Models
{
    public class DiaryItem
    {
        public int DiaryItemId { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public Project? Project { get; set; }

        public DiaryItem()
        {

        }

        public DiaryItem(int diaryId, DateTime dateTime, string description, Project? project)
        {
            DiaryItemId = diaryId;
            DateTime = dateTime;
            Description = description;
            Project = project;
        }

        public DiaryItem(DateTime dateTime, string description, Project? project)
        {
            DateTime = dateTime;
            Description = description;
            Project = project;
        }
    }

}
