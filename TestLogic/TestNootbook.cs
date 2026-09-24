using Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestLogic
{
    public class TestNootbook
    {
        [Fact]
        public void ListUnits()
        {
            NoteBook noteBook = new NoteBook();

            Unit[] result = noteBook.ListUnits();

            Assert.Empty(result);
        }
    }
}
