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

        public void Add(Module module)
        {
            Listmodules.Add(module);
        }

        public void Remove(Module module) 
        {
            Listmodules.Remove(module);
        }

        public List<AvgScore> ComputeAverages(Exam[] exams)
        {
            List<AvgScore> averages = new List<AvgScore>();

            foreach (Module module in ListModules())
            {
                AvgScore avg = module.ComputeAverage(exams);

                if (avg != null)
                {
                    averages.Add(avg);
                }
            }

            return averages;
        }
    } 
}
