using Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestLogic
{
    public class TestNotebook
    {
        [Fact]
        public void ListUnits()
        {
            NoteBook noteBook = new NoteBook();

            Unit[] result = noteBook.ListUnits();

            Assert.Empty(result);
        }
        [Fact]
        public void Testadd()
        {
            NoteBook noteBook = new NoteBook();

            Unit unit = new Unit();
            unit.Name = "Test";
            unit.Coef = 1;
            noteBook.AddUnit(unit);
            var units = noteBook.ListUnits();
            Assert.Single(units);
            Assert.Same(unit, units[0]);
            var u2 = new Unit();
            u2.Name = "Test";
            u2.Coef = 2;
            Assert.Throws<Exception>(() => { noteBook.AddUnit(u2); });
            u2.Name="Test2";
            noteBook.AddUnit(u2);
            units = noteBook.ListUnits();
            Assert.Equal(2, units.Length);
            Assert.Same(u2, units[1]); 
        }
        [Fact]
        public void Testremove()
        {
            NoteBook noteBook = new NoteBook();

            Unit unit = new Unit();
            unit.Name = "Test";
            unit.Coef = 1;
            noteBook.AddUnit(unit);

            Unit u2 = new Unit();
            u2.Name = "Test2";
            u2.Coef = 2;
            noteBook.AddUnit(u2);

            var units = noteBook.ListUnits();
            Assert.Equal(2, units.Length);

            noteBook.RemoveUnit(unit);

            units = noteBook.ListUnits();
            Assert.Single(units);
            Assert.Same(u2, units[0]);

            noteBook.RemoveUnit(u2);

            units = noteBook.ListUnits();
            Assert.Empty(units);
        }
        [Fact]
        public void TestListExam()
        {
            Module module = new Module() {Name = " Super module", Coef = 1.0f };

            Exam exam = new Exam() { Coef = 1.0f, Teacher = "Miaou ", Note = 20.0f, Module = module };

            NoteBook nb = new NoteBook();
            nb.AddExam(exam);

            Module[] modules = nb.ListModules();
            Assert.True(modules.Length == 1);
            Assert.Same(modules[0], module);

            Exam[] exams = nb.ListExam();
            Assert.True(exams.Length == 1);
            Assert.Same(exams[0], exam);
        }

    }
}
