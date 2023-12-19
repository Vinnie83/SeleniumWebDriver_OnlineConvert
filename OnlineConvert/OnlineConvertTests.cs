using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel;

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

       

        [Test]
        public void Test1()
        {
            driver.Url = baseUrl;

            var consentButton = driver.FindElement(By.ClassName("fc-button-label"));
            consentButton.Click();

            var docConverter = driver.FindElement(By.XPath("//h3[contains(.,'Document converter')]"));
            docConverter.Click();

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0, 500);");

            var pdfConverter = driver.FindElement(By.XPath("//p[@class='mb-0 opacity-75'][contains(.,'Convert your document or image to PDF with this free online PDF converter. " +
                "Support for over 250 source formats.')]"));
            pdfConverter.Click();

            
            js.ExecuteScript("window.scrollBy(0, 500);");

            var startButton = driver.FindElement(By.XPath("//button[contains(@class,'btn btn-lg submit-btn mb-0 white-space-nowrap mr-3 mb-3 d-flex align-items-center')]"));
            startButton.Click();
            Thread.Sleep(10000);

          
            var notNow = driver.FindElement(By.XPath("//*[@id=\"qg-toast\"]/div[2]/div/div/div/p[4]/button"));
            notNow.Click();

            Thread.Sleep(20000);

            var downloadButton = driver.FindElement(By.XPath("//*[@id=\"page_function_container\"]/div/div/div/div[1]/div[10]/div[2]/div[2]/div/div[3]/div/a"));
            downloadButton.Click();

            Thread.Sleep(5000);

            string directoryPath = "D:\\Documents\\Downloads";

            string filePattern = "example*";

            bool fileExists = Directory.GetFiles(directoryPath, filePattern).Any();

            Assert.That(fileExists, Is.True);



        }
    }
}