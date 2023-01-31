using BMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BMISBLayer.Repositories
{
    public interface IHomeRepository
    {
        List<Project> GetAllProjects(string s);
    }
}
