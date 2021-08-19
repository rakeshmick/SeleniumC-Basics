using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tutorial
{
    class TurnUpPage
    {
        IWebDriver driver;

        public TurnUpPage(IWebDriver driver) {

            this.driver = driver;
        }

        By Username = By.Id("UserName");
        By Password = By.Id("Password");
        By submitButton = By.CssSelector(".btn.btn-default");

        public void login(String username, String pasword) {
            driver.FindElement(Username).SendKeys(username);
            driver.FindElement(Password).SendKeys(pasword);
            driver.FindElement(submitButton).Click();
        }
        
    }
}
