using Logic;
using System.Reflection;

namespace TestLogic
{
    public class TestEducatonalElement
    {
        [Fact]
        public void Testexeption()
        {
            EducationalElement element = new EducationalElement();
            Assert.Throws<Exception>(() => { element.Name = ""; });
            element.Name = "math";
            Assert.Equal("math", element.Name);
        }
        [Fact]
        public void TestCoefException()
        {
            EducationalElement element = new EducationalElement();
            Assert.Throws<Exception>(() => { element.Coef = 0; });
            element.Coef = 1.5f;
            Assert.Equal(1.5, element.Coef, 3);
        }
    }
}
