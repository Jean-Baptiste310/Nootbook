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

        public Unit()
        {
            Module test = new Module();
            test.Name = "test";
            test.Coef = 1;
            Listmodules.Add(test);
        }
    } 
}
