using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Unit : EducationalElement
    {
        public List<Module> Listmodules = new List<Module>();

        public Unit[] ListModules()
        {
            return ListModules().ToArray();
        }
    } 
}
