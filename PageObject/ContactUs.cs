using Casos_de_prueba_Musala_Soft.Handler;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Casos_de_prueba_Musala_Soft.PageObject
{
    internal class ContactUs
    {
        protected IWebDriver Driver;

        protected By nombre = By.Name("your-name");
        protected By email = By.Name("your-email");
        protected By mobile = By.Name("mobile-number");
        protected By subject = By.Name("your-subject");
        protected By message = By.Name("your-message");
        protected By entercode = By.Id("siwp_captcha_value_0");
        protected By send = By.ClassName("btn-cf-submit");

        //constructor lanza una exception si el titulo de la pagina del contact us no es el correcto
        public ContactUs(IWebDriver driver)
        {
            Driver = driver;
            //if (!Driver.Equals("Musala Soft")) throw new Exception("This is not the Contact Us page");
        }

        public void TypeName(string name)
        {
            Driver.FindElement(nombre).Clear();
            Driver.FindElement(nombre).SendKeys(name);
        }
        public void Email(string mail) 
        {
            Driver.FindElement(email).Clear();
            Driver.FindElement(email).SendKeys(mail);
        }
        public void Mobile(string phone) 
        {
            Driver.FindElement(mobile).Clear();
            Driver.FindElement(mobile).SendKeys(phone);
        }
        public void Subject(string text) 
        {
            Driver.FindElement(subject).Clear();
            Driver.FindElement(subject).SendKeys(text);
        }
        public void Message(string text) 
        {
            Driver.FindElement(message).Clear();
            Driver.FindElement(message).SendKeys(text);
        }
        public void Entercode(string code) 
        {
            Driver.FindElement(entercode).Clear();
            Driver.FindElement(entercode).SendKeys(code);
        }
        public void Send() 
        {            
            Driver.FindElement(send).Click();
        }

        public ContactUs ContactUsPage(string name, string mail, string phone, string text, string msg, string code) 
        {
            TypeName(name);
            Email(mail);
            Mobile(phone);
            Subject(text);
            Message(msg);
            Entercode(code);
            Send();
            return new ContactUs(Driver);
        }
        //metodo para detectar si el formulario del contact us esta cargado
        //retorna true si cualquier elemento del formulario esta presente sino retorna falso en este caso escogimos el nombre
        public bool formIsPresent() 
        {
            return WaitHandler.ElementIsPresent(Driver, nombre);
        }
        public string Errormail()
        {
            string text = "";
            By errorMail = By.ClassName("wpcf7-not-valid-tip");
            if(WaitHandler.ElementIsPresent(Driver, errorMail)){
                text = Driver.FindElement(errorMail).Text;
            }
            return text;
        }
        
    }
}
