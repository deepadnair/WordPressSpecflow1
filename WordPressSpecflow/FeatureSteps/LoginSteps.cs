using Docker.DotNet.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using WordPressSpecflow.Pages;

namespace WordPressSpecflow
{
    [Binding]
    public class LoginSteps
    {

        public IWebDriver driver;
        LoginPObject loginPage = null;
        public LoginSteps()
          {
            driver = new ChromeDriver();
            
         // driver = ScenarioContext.Current.Get<IWebDriver>("currentDriver");
           }
        [Given(@"I Navigate to the Login page")]
        public void GivenINavigateToTheLoginPage()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:10080/wordpress/wp-login.php"); 
        }
        
        [When(@"I Login with Username '(.*)' and Password '(.*)' on the Login Page")]
        public void WhenILoginWithUsernameAndPasswordOnTheLoginPage(string username, string password)
        {
            LoginPObject loginPage = new LoginPObject(driver);
            loginPage.LoginAs(username, password);
        }
        
        [When(@"I Unsucessfully Login with Username '(.*)' and Password '(.*)' on the Login Page")]
        public void WhenIUnsucessfullyLoginWithUsernamePasswordOnTheLoginPage(string username, string password)
        {
            LoginPObject loginPage = new LoginPObject(driver);
            loginPage.LoginUnsuccessfullyAs(username, password);
        }
        
        [Then(@"the User Name '(.*)' Should be seen on the Dashboard Page")]
        public void ThenTheUserNameShouldBeSeenOnTheDashboardPage(string expecteduser)
        {
            DashboardPObject dashboardPage = new DashboardPObject(driver);
            
            Assert.IsTrue(dashboardPage.GetUser().Contains(expecteduser));
        }
        
        [Then(@"I Should See Error Message '(.*)' on the Login Page")]
        public void ThenIShouldSeeErrorMessageOnTheLoginPage(string GetErrorMessage)
        {
            LoginPObject loginPage = new LoginPObject(driver);
            loginPage.GetErrorMessage();
        }
    }
}
