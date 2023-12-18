using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OnlineConvert
{
    public class OnlineConvertTests
    {

        private const string baseUrl = "https://www.online-convert.com/";
        private WebDriver driver;   


        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

        }

        [TearDown]

        public void TearDown() 
        
        {
        
            driver.Quit();
        }

        [Test]
        public void Test1()
        {
            driver.Url = baseUrl;
            
            Assert.Pass();
        }
    }
}