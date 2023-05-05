using Casos_de_prueba_Musala_Soft.Handler;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casos_de_prueba_Musala_Soft.PageObject
{
   public class LoginPage
    {
        // selenium driver
        protected IWebDriver Driver;

        // localizadores
        protected By btnCookies = By.Id("wt-cli-accept-all-btn"); 
        protected By btnContactus = By.ClassName("fancybox");

        public LoginPage(IWebDriver driver) 
        {
            Driver= driver;

        }

        // metodo para hacer click en el Select us button
        public void ClickContactUsButton() 
        {
            if (WaitHandler.ElementIsPresent(Driver, btnContactus))
            {
                Driver.FindElement(btnCookies).Click();
                Driver.FindElement(btnContactus).Click();
            }
        }

    }
}
