using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class AvgScore
    {
        private EducationalElement educationalelement;

        private float average;

        public float Average
        {
            get { return  average; }
            set { average = value; }
        }

        public EducationalElement Educationalelement
        {
            get { return  educationalelement; }
            set {  educationalelement = value; }
        }

        public AvgScore(float average, EducationalElement educationalelement)
        {
            Average = average;
            Educationalelement = educationalelement;
        }

        public override string ToString()
        {
            return $"{Educationalelement} : {Average}";
        }
    }
}
