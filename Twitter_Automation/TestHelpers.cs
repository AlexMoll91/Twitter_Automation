using System;
using System.Globalization;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Twitter_Automation
    {
    public class TestHelpers
    {
        public static int Followed = 0;
        public static int Unfollowed = 0;

        public void Fill200(string source, FirefoxDriver driver, int totalFollows)
            {
            var totalFollowed = 0;

            driver.Navigate().GoToUrl(new Uri(source));
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15000));

            while (totalFollowed != totalFollows)
                {
                wait.Until(
                ExpectedConditions.ElementIsVisible(By.XPath("//div/ul/li/a/span[@class and text()='Follow']")));

                var followButtonList =
                    driver.FindElements(By.XPath("//div/ul/li/a/span[@class and text()='Follow']"));

                //THIS IS WHERE THE RAPID CLICKS HAPPEN
                foreach (var button in followButtonList)
                    {
                    try
                        {
                        button.Click();
                        Thread.Sleep(5500);
                        totalFollowed++;
                            Followed++;
                        }
                    catch (Exception)
                        {


                        }

                    }
                }
            Console.WriteLine(totalFollowed + " people followed.");

            }
        public void UnfollowPeople(string url, FirefoxDriver driver, int totalUnfollows)
            {
            var totalremoved = 0;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15000));
            driver.Navigate().GoToUrl(url);
            while (totalremoved != totalUnfollows)
                {
                wait.Until(
                    ExpectedConditions.ElementIsVisible(By.XPath("//div/ul/li/a/span[@class and text()='Unfollow']")));

                var removeHaterList = driver.FindElements(By.XPath("//div/ul/li/a/span[@class and text()='Unfollow']"));

                foreach (var hater in removeHaterList)
                    {
                    try
                        {
                        Thread.Sleep(5500);
                        hater.Click();
                        totalremoved++;
                            Unfollowed++;
                        }
                    catch (Exception)
                        {


                        }

                    }
                }
            Console.WriteLine(totalremoved + " people unfollowed.");
            }

        public static string WhatDo(FirefoxDriver driver)
        {
            int followerCount;
            int unfollowerCount;
            driver.Navigate().GoToUrl("https://twitter.com/oneironaught718");

            
            unfollowerCount = int.Parse(driver.FindElement(By.XPath(".//*[@id='page-container']/div[1]/div/div[2]/div/div/div[2]/div/div/ul/li[2]/a/span[2]")).Text.Replace(".","").Replace("K","").PadRight(5,'0'));
            followerCount = int.Parse(driver.FindElement(By.XPath(".//*[@id='page-container']/div[1]/div/div[2]/div/div/div[2]/div/div/ul/li[3]/a/span[2]")).Text.Replace(".", "").Replace("K", "").PadRight(5, '0'));
            Console.WriteLine("unfollower count: " + unfollowerCount + " follower count: " + followerCount);
            
            return followerCount > unfollowerCount ? "follow" : "unfollow";
        }
        }

    public static class Sources
        {
        //Opeth
        public static string sourceOne { get; set; }
        //Tool
        public static string sourceTwo { get; set; }
        //Roadrunner Records
        public static string sourceThree { get; set; }
        //Nuclear Blast Records
        public static string sourceFour { get; set; }
        //Century Media Records
        public static string sourceFive { get; set; }
        //Unfollow List
        public static string sourceUnfollow { get; set; }

        static Sources()
        {
            sourceOne =
                "https://community.statusbrew.com/twitter/1246601462/source/bb1831e96336d3313f64fa9a1b106958#activity/{" +
                "\"request_type\":\"followers\",\"exclude_pf\":true,\"has_avatar\":1,\"filter_graph\":\"not_following\",\"followers_max\":350,\"following_max\":200,\"orderby\":\"last_tweeted\",\"lasttweet_max\":7,\"age_min\":30,\"zombie_lvl\":\"no_zombie\"}";
            sourceTwo =
                "https://community.statusbrew.com/twitter/1246601462/source/03f45c352e4cef3126e6df34145647a6#activity/{" +
                "\"request_type\":\"followers\",\"exclude_pf\":true,\"has_avatar\":1,\"filter_graph\":\"not_following\",\"followers_max\":350,\"following_max\":200,\"orderby\":\"last_tweeted\",\"lasttweet_max\":7,\"age_min\":30,\"zombie_lvl\":\"no_zombie\"}";
            sourceThree =
                "https://community.statusbrew.com/twitter/1246601462/source/638a12f57bd1c78274dcd80f1de8d752#activity/{" +
                "\"request_type\":\"followers\",\"exclude_pf\":true,\"has_avatar\":1,\"filter_graph\":\"not_following\",\"followers_max\":350,\"following_max\":200,\"orderby\":\"last_tweeted\",\"lasttweet_max\":7,\"age_min\":30,\"zombie_lvl\":\"no_zombie\"}";
            sourceFour =
                "https://community.statusbrew.com/twitter/1246601462/source/78f811dfee13bff9da33a956eea96454#activity/{" +
                "\"request_type\":\"followers\",\"exclude_pf\":true,\"has_avatar\":1,\"filter_graph\":\"not_following\",\"followers_max\":350,\"following_max\":200,\"orderby\":\"last_tweeted\",\"lasttweet_max\":7,\"age_min\":30,\"zombie_lvl\":\"no_zombie\"}";
            sourceFive =
                "https://community.statusbrew.com/twitter/1246601462/source/e33468b6095a3992fcccfe2366ac9ea5#activity/{" +
                "\"request_type\":\"followers\",\"exclude_pf\":true,\"has_avatar\":1,\"filter_graph\":\"not_following\",\"followers_max\":350,\"following_max\":200,\"orderby\":\"last_tweeted\",\"lasttweet_max\":7,\"age_min\":30,\"zombie_lvl\":\"no_zombie\"}";
            sourceUnfollow = "https://community.statusbrew.com/twitter/1246601462#activity/{" +
                             "\"request_type\":\"nfb\",\"exclude_rf_days\":5,\"filter_graph\":\"following\",\"orderby\":\"last_tweeted\",\"orderdir\":\"asc\"}";
        }
    }
}
