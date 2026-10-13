using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Logic
{
    public class Unit : EducationalElement
    {
        public List<Module> Listmodules = new List<Module>();

        public Module[] ListModules()
        {
            return Listmodules.ToArray();
        }

        
    } 
}
