using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;

namespace Tutorial
{
    class TestClass
    {
      

        [Test]
        public void seleniumFirstTest()
        {
            IWebDriver driver = new ChromeDriver();
            try
            {
               
                driver.Url = "http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f";
                IWebElement usernameField = driver.FindElement(By.Id("UserName"));
                usernameField.SendKeys("hari");
                driver.FindElement(By.Id("Password")).SendKeys("123123");
                driver.FindElement(By.CssSelector(".btn.btn-default")).Click();
                IWebElement dashBoardMenuButton = driver.FindElement(By.ClassName("dropdown-toggle"));
                Assert.IsTrue(dashBoardMenuButton.Displayed);

                driver.FindElement(By.CssSelector(".dropdown-menu")).Click();

                ReadOnlyCollection<IWebElement> menu = driver.FindElements(By.CssSelector("div.navbar.navbar-inverse.navbar-fixed-top > div > div > ul > li.dropdown.open > ul li"));
            
                foreach (IWebElement link in menu)
                {
                    string text = link.Text;
                    if (Regex.IsMatch("Time & Materials", text))
                    {
                        link.Click();
                    }
                }

                IWebElement createNewButton = driver.FindElement(By.CssSelector(".btn.btn-primary"));
                Assert.IsTrue(createNewButton.Displayed);
                driver.Close();
                
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                driver.Close();
                driver.Quit();
            }



        }

    }
}
