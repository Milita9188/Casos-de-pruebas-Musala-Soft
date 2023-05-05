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

    //clase q contiene los casos de prueba del Careers
    [TestFixture]// anotacion de Nunit para marcar una clase que contenga casos de prueba
    public class CareersTest
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
        //verifica que que la página "Únase a nosotros" esté abierta (puede verificar que la URL sea correcta: http://www.musala.com/careers/join-us/
        [Test]
        public void correctURL()
        {
            Careers cPage = new Careers(driver);
            cPage.ClickCareers();
            Assert.AreEqual("https://www.musala.com/careers/join-us/", driver.Url);
        }

        //Desde el menú desplegable 'Seleccionar ubicación', seleccione 'Cualquier lugar'
        [Test]
        public void SelectLocationTest()
        {
            IWebElement locationButton = driver.FindElement(By.Id("get_location"));
            IReadOnlyCollection<IWebElement> location = (IReadOnlyCollection<IWebElement>)locationButton.FindElements(By.TagName("option"));
            foreach (IWebElement option in location)
            {
                if (option.Text.Equals("Anywhere"))
                    option.Click();
            }
        }
        //Verifica que se muestren 4 secciones principales
        [Test]
        public void Verifysection()
        {
            Careers cPage = new Careers(driver);
            cPage.ClickpositionByname();
            Assert.IsTrue(cPage.Sections("General Description"));
            Assert.IsTrue(cPage.Sections("Requirements"));
            Assert.IsTrue(cPage.Sections("Responsibilities"));
            Assert.IsTrue(cPage.Sections("What we offer"));

        }
        //Verifique que el botón 'Aplicar' esté presente en la parte inferior y Haga clic en el botón 'Aplicar'
        [Test]
        public void actionApply()
        {
            Careers cPage = new Careers(driver);
            Assert.IsTrue(cPage.applyIsPresent());
            cPage.ClickApply();
        }

        //Verifique los mensajes de error mostrados
        [Test]
        public void VerifyshownerrormessagesTest()
        {
            Careers cPage = new Careers(driver);
            
            string name = "";
            string mail = "test@test";
            string phone = "";
            string LkINDProfile = "Probando";
            string msg = "";
            string path = "D:\\Docs\\Automation.docx";


            cPage.Apply(name, mail, phone, path, LkINDProfile, msg);
            Assert.AreEqual("The field is required.", cPage.Errorname());
            Assert.AreEqual("The e-mail address entered is invalid.", cPage.Errormail());
            Assert.AreEqual("The field is required.", cPage.ErrorMobile());
            Assert.AreEqual("The field is required.", cPage.ErrorMessege());
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
