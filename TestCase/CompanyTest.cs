using Casos_de_prueba_Musala_Soft.PageObject;
using Casos_de_prueba_Musala_Soft.Reports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casos_de_prueba_Musala_Soft.TestCase
{
    //clase q contiene los casos de prueba del CompanyTest
    [TestFixture]// anotacion de Nunit para marcar una clase que contenga casos de prueba
    public class CompanyTest
    {
        //selenium driver
        protected IWebDriver driver;

        [SetUp]
        //SetUp: anotacion de Nunit para ejecutar un metodo antes de cada test
        //metodo para iniciar el navegador y navegar a una url
        public void BeforeTest()
        {
            ExtentReporting.CreateTest(TestContext.CurrentContext.Test.MethodName);

            string browser = ConfigurationManager.AppSettings.Get("browser");
            string URL = ConfigurationManager.AppSettings.Get("url");
            if (browser == "chrome")
                driver = new ChromeDriver();
            else if (browser == "firefox")
                driver = new FirefoxDriver();

            driver.Navigate().GoToUrl(URL);
        }
        //Verifica que la Url es http://www.musala.com/company/ y que existe la seccionde Liderazgo
        [Test]
        public void actuallyURL() 
        {
            Company cPage = new Company(driver);
            cPage.ClickCompany();
            Assert.AreEqual("https://www.musala.com/company/", driver.Url);
            Assert.IsTrue(cPage.LeaderShipSection());
        }

        //Verifica que la Url de facebook es https://www.facebook.com/MusalaSoft?fref=ts y que existe la imagen de perfil de Musala
        [Test]
        public void VerifiedFacebookUrl()

        {
            Company cPage = new Company(driver);
            cPage.ClickFacebooklink();
            var browserTabs = driver.WindowHandles;
            driver.SwitchTo().Window(browserTabs[1]);
            Assert.AreEqual("https://www.facebook.com/MusalaSoft?fref=ts", driver.Url);
            Assert.IsTrue(cPage.ImageMusala());
        }

        [TearDown]
        //Teardown: anotacion de Nunit para ejecutar un metodo despues de cada test
        //metodo para cerrar el navegador
        public void AfterTest()
        {
            if (driver != null)
            {
                driver.Quit();
                EndTest();
                ExtentReporting.EndReporting();
            }
        }

        private void EndTest()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var message = TestContext.CurrentContext.Result.Message;

            switch (testStatus)
            {
                case NUnit.Framework.Interfaces.TestStatus.Failed:
                    ExtentReporting.LogFail($"Test has failed {message}");
                    break;
                case NUnit.Framework.Interfaces.TestStatus.Skipped:
                    ExtentReporting.LogPass($"Test has skipped {message}");
                    break;
                default:
                    break;
            }

            ExtentReporting.LogPass($"Endind Test");
        }
    }
}
