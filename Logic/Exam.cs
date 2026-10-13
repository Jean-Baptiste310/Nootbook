using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Exam
    {
        private Module module;

        private string teacher;

        private DateTime date;

        private float coef;

        private float note;

        private bool isAbsent;


        public Module Module
        {
            get => module; set => module = value;
        }

        public string Teacher
        {
            get => teacher;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("The teacher must be not empty");
                }
                teacher = value;
            }
        }

        public DateTime Date
        {
            get => date;
            set => date = value;
        }

        public float Coef
        {
            get => coef;
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("The coef must be not null or empty");
                }
                coef = value;
            }
        }

        public float Note
        {
            get => note;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The note must be not null or empty");
                }
                note = value;
            }
        }

        public bool IsAbsent
        {
            get => isAbsent;
            set => isAbsent = value;
            
        }



    }
}
