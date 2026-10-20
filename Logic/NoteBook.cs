using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class NoteBook
    {
        public List<Unit> ListUnit = new List<Unit>();
        public List<Module> ListModule = new List<Module>();
        public List<Exam> exams = new List<Exam>();

        public Unit[] ListUnits()
        {
            return ListUnit.ToArray();
        }

       public void AddUnit(Unit unit)
        {
            if (ListUnit.Find((u) => { return u.Name == unit.Name; }) != null)
                throw new Exception("An unit with this name is already exit");
            ListUnit.Add(unit);
        }

        public void RemoveUnit(Unit unit)
        {
            ListUnit.Remove(unit);
        }

        public Module[] ListModules()
        {
            List<Module> modules = new List<Module>();

            foreach (Unit unit in ListUnit)
            {
                foreach (Module module in unit.ListModules())
                {
                    if (!modules.Contains(module))
                    {
                        modules.Add(module);
                    }
                }
            }
            return modules.ToArray();
        }

        public void AddModule(Unit unit, Module module)
        {
            if (unit == null)
                throw new Exception("Please select a unit.");

            if (unit.Listmodules.Exists(m => m.Name == module.Name))
                throw new Exception("A module with this name already exists.");

            unit.Listmodules.Add(module);
        }

        public void RemoveModule(Module module)
        {
            ListModule.Remove(module);
        }

        public void AddExam(Exam exam)
        {
            exams.Add(exam);
        }
    }
}
