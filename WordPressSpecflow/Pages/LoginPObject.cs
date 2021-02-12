using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace WordPressSpecflow.Pages
{
   public class LoginPObject
    {

        public  static IWebDriver Driver;
        public LoginPObject(IWebDriver driver)
        {
           Driver = driver;

        }

        IWebElement UsernameTxtBox = Driver.FindElement(By.Id("user_login"));
       
        IWebElement PasswordTxtBox = Driver.FindElement(By.Id("user_pass"));
       
        IWebElement LoginBtn = Driver.FindElement(By.Id("wp-submit"));
       
        IWebElement ErrorText = Driver.FindElement(By.Id("login_error"));

        
        public DashboardPObject LoginAs(string username, string password)
        {
            Login(username, password);
            return new DashboardPObject(Driver);
        }

        public LoginPObject LoginUnsuccessfullyAs(string username, string password)
        {
            Login(username, password);
            return this;
        }

        public string GetErrorMessage()
        {
            return ErrorText.Text;
        }

        public void Login(string username, string password)
        {
            UsernameTxtBox.SendKeys("username");
            PasswordTxtBox.SendKeys("password");
            LoginBtn.Click();
        }
    }
}
