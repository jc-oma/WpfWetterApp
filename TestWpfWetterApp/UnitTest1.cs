using WpfWetterApp;

namespace TestWpfWetterApp
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestKelvinToCelsius()
        {
            var temp = 0.00;
            var expectedResult = -272.15;

            double testValue = WpfWetterApp.MainWindow.KelvinToCelsius(temp);

            Assert.AreEqual(expectedResult, testValue);
        }
    }
}