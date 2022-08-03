﻿using ConcreteNg.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Repositories.Interfaces
{
    public interface IProjectTaskItemRepository : IRepository<ProjectTaskItem>
    {
        void DeleteProjectTaskItems(int taskId);
    }
}