using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Module : EducationalElement
    {
        public AvgScore ComputeAverage(Exam[] exams)
        {
            float total = 0;
            float totalCoef = 0;

            foreach (Exam e in exams)
            {
                if (e.Module == this && !e.IsAbsent)
                {
                    total += e.Note * e.Coef;
                    totalCoef += e.Coef;
                }
            }

            if (totalCoef == 0)
                return null;

            float avg = total / totalCoef;
            return new AvgScore(avg, this);
        }
    }
}
