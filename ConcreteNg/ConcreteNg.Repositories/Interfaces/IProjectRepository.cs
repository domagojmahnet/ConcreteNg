﻿using ConcreteNg.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Repositories.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        List<Project> GetActiveProjects(int employerID);
        List<Project> GetProjects(int employerID);
    }
}
