using System;
using System.Collections.Generic;
using System.Text;
using Logic;

namespace TestLogic
{
    public class Testunit
    {
        [Fact]
        public void TestListmodule() 
        {
            Unit unit = new Unit();
            unit.Name = "Test";
            unit.Coef = 1;

            Module[] module = unit.ListModules();

            Assert.Empty(module);
        }
    }
}
