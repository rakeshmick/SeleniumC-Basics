using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Tutorial
{
    class TestClass
    {
        IWebDriver driver;

           [Test]
        public void seleniumSecondTest()
        {
            driver = new ChromeDriver();
            driver.Url = "http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f";
            TurnUpPage tpage = new TurnUpPage(driver);
            tpage.login("hari","123123");
        }

            [Test]
        public void seleniumFirstTest()
        {
            driver = new ChromeDriver();
            try
            {
               
                driver.Url = "http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f";
              //  driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                IWebElement usernameField = driver.FindElement(By.Id("UserName"));
                usernameField.SendKeys("hari");
                driver.FindElement(By.Id("Password")).SendKeys("123123");
                driver.FindElement(By.CssSelector(".btn.btn-default")).Click();
                IWebElement dashBoardMenuButton = driver.FindElement(By.ClassName("dropdown-toggle"));
                Assert.IsTrue(dashBoardMenuButton.Displayed);
                dashBoardMenuButton.Click();
                //driver.FindElement(By.CssSelector(".dropdown-menu")).Click();

                ReadOnlyCollection<IWebElement> menu = driver.FindElements(By.CssSelector("div.navbar.navbar-inverse.navbar-fixed-top > div > div > ul > li.dropdown.open > ul li"));
            
                foreach (IWebElement link in menu)
                {
                    string text = link.Text;
                    if (Regex.IsMatch("Time & Materials", text))
                    {
                        link.Click();
                        break;
                    }
                }

                IWebElement createNewButton = driver.FindElement(By.CssSelector(".btn.btn-primary"));
                Assert.IsTrue(createNewButton.Displayed);
                createNewButton.Click();

                IWebElement uploadButton = driver.FindElement(By.Id("files"));
                uploadButton.SendKeys("C:\\Users\\Rakesh P\\source\\repos\\Tutorial\\Tutorial\\Printer.cs");
                driver.FindElement(By.Id("Code")).SendKeys("23");
                driver.FindElement(By.Id("Description")).SendKeys("descriptive test");
                driver.FindElement(By.Id("SaveButton")).Click();

                WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
                wait.Until(ExpectedConditions.ElementExists((By.CssSelector(".k-icon.k-i-seek-e")))).Click();

                Thread.Sleep(2000);
                ReadOnlyCollection<IWebElement>  rowsInTheTable = driver.FindElements(By.CssSelector("#tmsGrid > div.k-grid-content > table > tbody > tr"));
                Console.WriteLine("number of rows in table : " + rowsInTheTable.Count);
                String actual =driver.FindElement(By.CssSelector("#tmsGrid > div.k-grid-content > table > tbody > tr:nth-child(" + rowsInTheTable.Count + ") td:nth-child(1)")).Text;
                Assert.AreEqual("23", actual);
                driver.Close();
                
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                driver.Close();
                driver.Quit();
                Assert.Fail();
            }



        }

    }
}
