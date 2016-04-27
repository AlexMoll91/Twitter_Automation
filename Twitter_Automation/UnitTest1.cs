using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Twitter_Automation
    {

    [TestFixture]
    public class UnitTest1
        {
        private static FirefoxDriver driver;
        public static WebDriverWait wait;

        [Test]
        public void McTesterSon()
            {
            //Instatiating Variabnunit-console nunit.tests.dllles
            var listCount = 0;
            var tw = new TestHelpers();
            var sourcesEnum = new List<string>
            {
                Sources.sourceOne,
                Sources.sourceTwo,
                Sources.sourceThree,
                Sources.sourceFour,
                Sources.sourceFive
            };
            driver = new FirefoxDriver();
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
            //Do the shit broo
            while (TestHelpers.Followed < 1000 && TestHelpers.Unfollowed < 1000)
                {

                if (TestHelpers.WhatDo(driver) == "follow")
                    {
                    tw.Fill200(sourcesEnum[listCount], driver, 100);
                    listCount++;
                    }

                else
                    {
                    tw.UnfollowPeople(Sources.sourceUnfollow, driver, 100);
                    }

                if (listCount == 4)
                    {
                    listCount = 0;
                    }

                }
            }
        }
    }
