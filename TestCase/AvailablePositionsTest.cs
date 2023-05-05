using Casos_de_prueba_Musala_Soft.Reports;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Casos_de_prueba_Musala_Soft.PageObject;

namespace Casos_de_prueba_Musala_Soft.TestCase
{
    //clase q contiene los casos de prueba del AvailablePositions
    [TestFixture]// anotacion de Nunit para marcar una clase que contenga casos de prueba
    
    public class AvailablePositionsTest
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

        [Test]
        //verifica que que la página "Únase a nosotros" esté abierta (puede verificar que la URL sea correcta: http://www.musala.com/careers/join-us/
        
        public void correctURL()
        {
            Careers cPage = new Careers(driver);
            cPage.ClickCareers();
            Assert.AreEqual("https://www.musala.com/careers/join-us/", driver.Url);
        }

        [Test]
        //Desde el menú desplegable 'Seleccionar ubicación', seleccione Sofia e imprime en consola el listado de posiciones disponibles
        public void SelectLocationSofiaTest()
        {
            string city = "Sofia";
            Careers cPage = new Careers(driver);
            cPage.SelectLocation(city);
            cPage.PositionsbyLocation(city);
        }

        [Test]
        //Desde el menú desplegable 'Seleccionar ubicación', seleccione Skopje e imprime en consola el listado de posiciones disponibles
        public void SelectLocationSkopjeTest()
        {
            string city = "Skopje";
            Careers cPage = new Careers(driver);
            cPage.SelectLocation(city);
            cPage.PositionsbyLocation(city);
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
