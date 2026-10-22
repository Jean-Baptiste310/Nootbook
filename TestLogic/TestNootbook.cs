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
            u2.Name = "Test2";
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
            Module module = new Module() { Name = " Super module", Coef = 1.0f };

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
        [Fact]
        public void TestAvgScore()
        {
            Module module = new Module()
            {
                Name = "Maths",
                Coef = 2.0f
            };

            AvgScore avg = new AvgScore(15.5f, module);

            Assert.Equal(15.5f, avg.Average);
            Assert.Same(module, avg.Educationalelement);
            Assert.Equal($"{module} : {avg.Average}", avg.ToString());
        }

        [Fact]
        public void TestComputeAverage()
        {
            Module module = new Module()
            {
                Name = "Maths",
                Coef = 2.0f
            };

            Exam exam1 = new Exam()
            {
                Module = module,
                Note = 10.0f,
                Coef = 1.0f,
                IsAbsent = false
            };

            Exam exam2 = new Exam()
            {
                Module = module,
                Note = 20.0f,
                Coef = 1.0f,
                IsAbsent = false
            };

            Exam[] exams = { exam1, exam2 };

            AvgScore result = module.ComputeAverage(exams);

            Assert.NotNull(result);
            Assert.Equal(15.0f, result.Average);
            Assert.Same(module, result.Educationalelement);
        }

        [Fact]
        public void TestComputeAverages()
        {
            // Arrange
            Unit unit = new Unit();

            Module module1 = new Module()
            {
                Name = "Maths",
                Coef = 2.0f
            };

            Module module2 = new Module()
            {
                Name = "Informatique",
                Coef = 1.0f
            };

            unit.Add(module1);
            unit.Add(module2);

            Exam exam1 = new Exam()
            {
                Module = module1,
                Note = 10.0f,
                Coef = 1.0f,
                IsAbsent = false
            };

            Exam exam2 = new Exam()
            {
                Module = module1,
                Note = 20.0f,
                Coef = 1.0f,
                IsAbsent = false
            };

            Exam[] exams = { exam1, exam2 };

            List<AvgScore> averages = unit.ComputeAverages(exams);

            Assert.Single(averages);
            Assert.Equal(15.0f, averages[0].Average);
            Assert.Same(module1, averages[0].Educationalelement);
        }

        [Fact]
        public void TestComputeScores()
        {
            NoteBook nb = new NoteBook();
            Unit unit = new Unit();
            Module module = new Module() { Name = "Maths", Coef = 1.0f };

            unit.Add(module);
            nb.AddUnit(unit);

            nb.AddExam(new Exam()
            {
                Module = module,
                Note = 15.0f,
                Coef = 1.0f,
                IsAbsent = false
            });

            List<AvgScore> scores = nb.ComputeScores();

            Assert.Contains(scores, s =>
                s.Educationalelement == module && s.Average == 15.0f);

            Assert.Contains(scores, s =>
                s.Educationalelement == unit && s.Average == 15.0f);
        }
    }
}
