using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace WordPressSpecflow.Pages
{
   public class DashboardPObject
    {

        public static IWebDriver driver;

        public DashboardPObject(IWebDriver driver)
        {
            driver = driver;

        }

        IWebElement UserNameTxt = driver.FindElement(By.CssSelector("#wp-admin-bar-my-account .ab-item"));
                
       
        /// <summary>
        /// Get Displayed User Name 
        /// </summary>
        /// <returns></returns>
        public string GetUser()
        {
            return UserNameTxt.Text;
        }
    }
}
