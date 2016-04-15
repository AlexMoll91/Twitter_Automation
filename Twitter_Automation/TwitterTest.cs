using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Twitter_Automation
    {
    [TestFixture]
    public class TwitterTest
        {
        private static ChromeDriver driver;
        public static WebDriverWait wait;

        [SetUp]
        public static void setUp()
            {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15000));
            }


        [Test]
        public void AutoFollow()
            {
            var s = new Sources();
            var tw = new TestHelpers();
            var sourceOne =
                @"https://community.statusbrew.com/twitter/1246601462/source/e4d7e5f219762636b1270e0620309b75#activity/{" +
                "\"request_type\":\"followers\",\"exclude_pf\":true,\"has_avatar\":1,\"filter_graph\":\"not_following\",\"followers_max\":350,\"following_max\":200,\"orderby\":\"last_tweeted\"}";


            //Open Main Page and Sign In
            driver.Navigate().GoToUrl(new Uri("http://www.statusbrew.com"));
            driver.Manage().Window.Maximize();
            driver.FindElement(By.XPath("//a[@class='js-signin-modal']")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@name='mail']")));
            driver.FindElement(By.XPath("//input[@name='mail']")).SendKeys("davidmieloch@gmail.com");
            driver.FindElement(By.XPath("//input[@type='password']")).SendKeys("*vPB@86rJKRj");
            driver.FindElement(By.XPath("//button[contains(.,'Sign In')]")).Click();

            //Fill First 5 sources with 200 hundred
            tw.Fill200(Sources.sourceOne, driver);
            tw.Fill200(Sources.sourceTwo, driver);
            tw.Fill200(Sources.sourceThree, driver);
            tw.Fill200(Sources.sourceFour, driver);
            tw.Fill200(Sources.sourceFive, driver);
            //Remove Haters
            tw.
            }
        }
    }
