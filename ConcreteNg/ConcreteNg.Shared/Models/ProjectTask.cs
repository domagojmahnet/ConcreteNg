using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConcreteNg.Shared.Models
{
    public class ProjectTask
    {
        public int ProjectTaskId { get; set; }
        public string ProjectTaskName { get; set; }
        public IEnumerable<ProjectTaskItem> ProjectTaskItems { get; set;}
        [JsonIgnore]
        public Project? Project { get; set; }

        public ProjectTask()
        {

        }

        public ProjectTask(int projectTaskId, string projectTaskName, IEnumerable<ProjectTaskItem> projectTaskItems, Project? project)
        {
            ProjectTaskId = projectTaskId;
            ProjectTaskName = projectTaskName;
            ProjectTaskItems = projectTaskItems;
            Project = project;
        }

        public ProjectTask(string projectTaskName, IEnumerable<ProjectTaskItem> projectTaskItems, Project? project)
        {
            ProjectTaskName = projectTaskName;
            ProjectTaskItems = projectTaskItems;
            Project = project;
        }
    }
}
