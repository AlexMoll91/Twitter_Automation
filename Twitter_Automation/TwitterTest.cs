using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Twitter_Automation
    {
    [TestClass]
    public class TwitterTest
        {
        private static ChromeDriver driver;
        public static WebDriverWait wait;

        [TestInitialize]
        public static void setUp()
            {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15000));
            }


        [TestMethod]
        public void AutoFollow()
            {
            //Instatiating Variables
            var s = new Sources();
            var tw = new TestHelpers();

            //Open Main Page and Sign In
            driver.Navigate().GoToUrl(new Uri("http://www.statusbrew.com"));
            driver.Manage().Window.Maximize();
            driver.FindElement(By.XPath("//a[@class='js-signin-modal']")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@name='mail']")));
            driver.FindElement(By.XPath("//input[@name='mail']")).SendKeys("davidmieloch@gmail.com");
            driver.FindElement(By.XPath("//input[@type='password']")).SendKeys("*vPB@86rJKRj");
            driver.FindElement(By.XPath("//button[contains(.,'Sign In')]")).Click();
            Thread.Sleep(5000);
            //Fill First 5 sources with 200 hundred
            tw.Fill200(s.sourceOne, driver);
            tw.Fill200(s.sourceTwo, driver);
            tw.Fill200(s.sourceThree, driver);
            tw.Fill200(s.sourceFour, driver);
            tw.Fill200(s.sourceFive, driver);
            //Remove Haters
            tw.UnfollowPeople(s.sourceUnfollow, driver);
            }
        }
    }
