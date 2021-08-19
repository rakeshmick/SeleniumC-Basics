using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tutorial
{
    class OrganizedNunitTest
    {
        IWebDriver driver;
        [SetUp]
        public void setUpTests()
        {
            driver = new ChromeDriver();
            driver.Url = "http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f";
        }

        [TearDown]
        public void tearDown()
        {
            driver.Close();
            driver.Quit();
        }

        [Test]
        public void seleniumSecondTest()
        {

            TurnUpPage tpage = new TurnUpPage(driver);
            tpage.login("hari", "123123");
        }
        [Test]
        public void seleniumThirdTest()
        {

            TurnUpPage tpage = new TurnUpPage(driver);
            tpage.login("hari", "123123");
        }
        [Test]
        public void seleniumFourthTest()
        {

            TurnUpPage tpage = new TurnUpPage(driver);
            tpage.login("hari", "123123");
        }
    }
}
