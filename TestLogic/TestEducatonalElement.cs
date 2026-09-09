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
        }
        [Fact]
        public void TestCoefException()
        {
            EducationalElement element = new EducationalElement();
            Assert.Throws<Exception>(() => { element.Coef = 0; });
        }
    }
}
