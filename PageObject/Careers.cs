using Casos_de_prueba_Musala_Soft.Handler;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casos_de_prueba_Musala_Soft.PageObject
{
    public class Careers
    {
        protected IWebDriver Driver;
        protected By careersButton = By.XPath("//*[@id=\"menu-main-nav-1\"]/li[5]/a");
        protected By ConsultOpenPositionsBtn = By.XPath("//*[@id=\"content\"]/div[1]/div/div[1]/div/section/div/a");
        protected By LocationButton = By.Id("get_location");
        protected By positionByname = By.XPath("//*[@id=\"content\"]/section/div[2]/article[2]/div/a");
        protected By requirements = By.ClassName("requirements");
        protected By btnApply = By.XPath("//*[@id=\"post-5434\"]/div/div[2]/div[2]/a");
        protected By fileupload = By.Id("uploadtextfield");

        //Selectores del formulario de aplicar
        protected By nombre = By.Id("cf-1");
        protected By email = By.Id("cf-2");
        protected By mobile = By.Id("cf-3");
        protected By CV = By.Id("cf-4");
        protected By LkINDProfile = By.Id("cf-5");
        protected By message = By.Id("cf-6");
        protected By checkbox = By.Id("adConsentChx");
        protected By send = By.ClassName("btn-cf-submit");

        //selectorer de posiciones disponibles
        protected By cardjobsHot = By.ClassName("card-jobsHot");

        public Careers(IWebDriver driver)
        {
            Driver = driver;
        }

        public void ClickCareers()
        {
            Driver.FindElement(careersButton).Click();
        }

        public void ClickOpenPositions()
        {
            Driver.FindElement(ConsultOpenPositionsBtn).Click();
        }

        
        public void ClickAnywhere() 
        {
            Driver.FindElement(LocationButton).Click();
        }

        public void ClickpositionByname()
        {
            Driver.FindElement(positionByname).Click();
        }

        public bool applyIsPresent()
        {
            return WaitHandler.ElementIsPresent(Driver, btnApply);
        }

        public void ClickApply()
        {
            Driver.FindElement(btnApply).Click();
        }

        public bool Sections(string text) 
        {
            IList<WebElement> elements = (IList<WebElement>)Driver.FindElements(requirements);

            foreach(WebElement element in elements)
            {
                if (element.FindElement(By.TagName("h2")).Text == text)
                    return true;

            }
            return false;
        }
        public void TypeName(string name)
        {
            Driver.FindElement(nombre).SendKeys(name);
        }
        public void Email(string mail)
        {
            Driver.FindElement(email).SendKeys(mail);
        }
        public void Mobile(string phone)
        {
            Driver.FindElement(mobile).SendKeys(phone);
        }
        public void CurriculumV(string text)
        {
            Driver.FindElement(CV).SendKeys(text);
        }
        public void Message(string text)
        {
            Driver.FindElement(message).SendKeys(text);
        }
        public void LinkedinProfile(string text)
        {
            Driver.FindElement(LkINDProfile).SendKeys(text);
        }
        public void CheckBoxx()
        {
            Driver.FindElement(checkbox).Click();
        }
        public void Send()
        {
            Driver.FindElement(send).Click();
        }

        public Careers Apply(string name, string mail, string phone, string path, string LkINDProfile, string msg)
        {
            TypeName(name);
            Email(mail);
            Mobile(phone);
            UploadCVitae(path);
            LinkedinProfile(LkINDProfile);
            Message(msg);
            CheckBoxx();

            Send();
            return new Careers(Driver);
        }
        public string Errorname()
        {
            By errorName = By.Id("cf-1");
            return Driver.FindElement(errorName).Text;
        }
        public string Errormail()
        {
            By errorMail = By.Id("cf-2");
            return Driver.FindElement(errorMail).Text;
        }

        public string ErrorMobile()
        {
            By errorMobile = By.Id("cf-3");
            return Driver.FindElement(errorMobile).Text;
        }

        public string ErrorMessege()
        {
            By errorMessege = By.Id("cf-3");
            return Driver.FindElement(errorMessege).Text;
        }

        public void UploadCVitae(string path) 
        {
            IWebElement cvUpload = Driver.FindElement(fileupload);

            cvUpload.SendKeys(@path);
        }

        public void SelectLocation(string city) 
        {
            IWebElement locationButton = Driver.FindElement(By.Id("get_location"));
            IReadOnlyCollection<IWebElement> location = (IReadOnlyCollection<IWebElement>)locationButton.FindElements(By.TagName("option"));
            foreach (IWebElement option in location)
            {
                if (option.Text.Equals(city))
                {
                    option.Click();
                    break;
                }
            }
        }

        public void PositionsbyLocation(string city)
        {
            IList<WebElement> elements = (IList<WebElement>)Driver.FindElements(cardjobsHot);

            foreach (WebElement element in elements)
            {
                var ocupation = element.FindElement(By.ClassName("card-jobsHot__title")).Text;
                var link = element.FindElement(By.ClassName("card-jobsHot__link")).Text;

                Console.WriteLine(city + "\n");
                Console.WriteLine("Position:" + ocupation + "\n");
                Console.WriteLine("More Info:" + link + "\n");
            }
        }
    }
}
