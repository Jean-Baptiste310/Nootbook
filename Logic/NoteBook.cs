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
            foreach (Exam exam in exams)
            {
                if (exam.Module != null && !modules.Contains(exam.Module))
                {
                    modules.Add(exam.Module);
                }
            }
            return modules.ToArray();
        }

        public Exam[] ListExam()
        {
            return exams.ToArray();
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

        public List<AvgScore> ComputeScores()
        {
            List<AvgScore> scores = new List<AvgScore>();

            Exam[] allExams = ListExam();

            float total = 0;
            float totalCoef = 0;

            foreach (Unit unit in ListUnit)
            {
                List<AvgScore> averages = unit.ComputeAverages(allExams);

                if (averages.Count > 0)
                {
                    float unitTotal = 0;
                    float unitCoef = 0;

                    foreach (AvgScore avg in averages)
                    {
                        scores.Add(avg);

                        Module module = (Module)avg.Educationalelement;
                        unitTotal += avg.Average * module.Coef;
                        unitCoef += module.Coef;
                    }

                    if (unitCoef > 0)
                    {
                        float unitAverage = unitTotal / unitCoef;
                        scores.Add(new AvgScore(unitAverage, unit));
                        total += unitAverage * unitCoef;
                        totalCoef += unitCoef;
                    }
                }
            }

            if (totalCoef > 0)
            {
                EducationalElement general = new EducationalElement();
                scores.Add(new AvgScore(total / totalCoef, general));
            }

            return scores;
        }
    }
}
