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
            if (ListUnit.Find((u) => { return u.Name == unit.Name; }) != null)
                throw new Exception("An unit with this name is already exit");
            ListUnit.Remove(unit);
        }
    }
}
