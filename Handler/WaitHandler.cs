using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V110.DOM;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casos_de_prueba_Musala_Soft.Handler
{
    //clase para manejar las esperas explicitas
    public class WaitHandler
    {
        //metodopara esperar por un elemento presente en la pag web
        //retorna true si encurntra el elemento en 3segundos, sino retorna falso

    public static bool ElementIsPresent(IWebDriver driver, By locator)
    {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));                    
                wait.Until(drv => drv.FindElement(locator));
                return true;
            }
            catch { }
            return false;
    }
    }
}
