using Casos_de_prueba_Musala_Soft.Handler;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casos_de_prueba_Musala_Soft.PageObject
{
    public class Company
    {
        protected IWebDriver Driver;

        protected By btnCookies = By.Id("wt-cli-accept-all-btn");
        protected By companybutton = By.XPath("//*[@id=\"menu-main-nav-1\"]/li[1]/a");
        protected By Leadership = By.ClassName("company-members");
        protected By FBbutton = By.XPath("/html/body/main/section[2]/div/div/div/a[4]");
        protected By ImagMusala = By.XPath("//*[@id=\"mount_0_0_F4\"]/div/div[1]/div/div[3]/div/div/div/div[1]/div[1]/div/div/div[1]/div[2]/div/div/div/div[1]/div/a/div/svg/g/image");

        public Company(IWebDriver driver)
        {
            Driver = driver;
        }
        public void ClickCompany()
        {
            Driver.FindElement(companybutton).Click();
        }

        public bool LeaderShipSection()
        {
            return WaitHandler.ElementIsPresent(Driver, Leadership);
        }
        public void ClickFacebooklink()
        {
            Driver.FindElement(btnCookies).Click();
            Driver.FindElement(FBbutton).Click();
        }
        public bool ImageMusala()
        {
            return WaitHandler.ElementIsPresent(Driver, ImagMusala);
        }
    }
}
