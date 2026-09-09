using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class NoteBook
    {
        public List<Unit> ListUnit = new List<Unit>();

        public Unit[] ListUnits()
        {
            return ListUnits().ToArray();
        }
    }
}
