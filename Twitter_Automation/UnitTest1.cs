using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Twitter_Automation
    {
    [TestFixture]
    public class UnitTest1
        {
        private static ChromeDriver driver;
        public static WebDriverWait wait;

        [Test]
        public void McTesterSon()
            {
            //Instatiating Variabnunit-console nunit.tests.dllles
            var s = new Sources();
            var tw = new TestHelpers();
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15000));
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
            tw.Fill200(s.sourceOne, driver, 200);
            tw.Fill200(s.sourceTwo, driver, 200);
            tw.Fill200(s.sourceThree, driver, 200);
            tw.Fill200(s.sourceFour, driver, 200);
            tw.Fill200(s.sourceFive, driver, 200);
            //Remove Haters
            tw.UnfollowPeople(s.sourceUnfollow, driver, 1000);
            }
        }
    }
