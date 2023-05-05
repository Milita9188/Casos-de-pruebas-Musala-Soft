using Casos_de_prueba_Musala_Soft.PageObject;
using Casos_de_prueba_Musala_Soft.Reports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casos_de_prueba_Musala_Soft.TestCase
{
    //clase q contiene los casos de prueba del ContactUs
    [TestFixture]// anotacion de Nunit para marcar una clase que contenga casos de prueba
    public class ContactUsTest
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
            else if(browser == "firefox")
                driver = new FirefoxDriver();

            driver.Navigate().GoToUrl(URL);
        }
       
        [Test]
        //Test: Anotacion de Nunit para marcar a un metodo como caso de prueba automatizado
        //metodo q implementa el caso de prueba del ContactUs. El resultado esperado es que el usuario se loguee correctamente
        public void SuccesEmailTest()
        {
            ContactUs cPage = new ContactUs(driver);
            LoginPage lPage = new LoginPage(driver);
            lPage.ClickContactUsButton();

            string name = "Misle";
            //string mail = "test@test";
            string phone = "5487822";
            string text = "Probando";
            string msg = "Hola mundo";
            string code = "4584";
                                   
            StreamReader sr = new StreamReader("C:\\Users\\milit\\source\\repos\\CP_MusalaSoft\\Casos de prueba Musala_Soft\\TestCase\\Testdata.txt");
            string mail = sr.ReadLine();
            while (mail != null)
            {
                cPage.ContactUsPage(name, mail, phone, text, msg, code);
                mail = sr.ReadLine();
                Assert.AreEqual("The e-mail address entered is invalid.", cPage.Errormail());
            }
            sr.Close();            
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
