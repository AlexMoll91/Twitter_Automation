﻿using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Twitter_Automation
    {
    public class TestHelpers
        {
        public void Fill200(string source, ChromeDriver driver)
            {
            for (var z = 0; z == 2; z++)
                {
                Thread.Sleep(5000);
                driver.Navigate().GoToUrl(new Uri(source));

                TwitterTest.wait.Until(
                    ExpectedConditions.ElementIsVisible(By.XPath("//div/ul/li/a/span[@class and text()='Follow']")));

                var followButtonList = driver.FindElements(By.XPath("//div/ul/li/a/span[@class and text()='Follow']"));

                //THIS IS WHERE THE RAPID CLICKS HAPPEN
                foreach (var button in followButtonList)
                    {
                    Thread.Sleep(5000);
                    button.Click();
                    }
                }
            }
        public static void UnfollowPeople(ChromeDriver driver)
            {
            var totalremoved = 0;
            while (totalremoved != 1000)
                {
                var removeHaterList =
                    driver.FindElements(
                        By.XPath("//a[@class='btn - activity btn btn - small btn - danger js - unfollow - user']"));
                foreach (var hater in removeHaterList)
                    {
                    hater.Click();
                    totalremoved++;
                    }
                }
            Console.WriteLine(totalremoved+" hataz UNFOLLOWED");
            }
        }

    public class Sources
        {
        //METALBLADE Records
        public static string sourceOne { get; set; }
        //EarAche Records
        public static string sourceTwo { get; set; }
        //Relapse Records
        public static string sourceThree { get; set; }
        //Tool Band
        public static string sourceFour { get; set; }
        //Opeth
        public static string sourceFive { get; set; }
        //Unfollow List
        public static string sourceUnfollow { get; set; }

        public Sources()
            {
            sourceOne =
                @"https://community.statusbrew.com/twitter/1246601462/source/e4d7e5f219762636b1270e0620309b75#activity/{" +
                "\"request_type\":\"followers\",\"exclude_pf\":true,\"has_avatar\":1,\"filter_graph\":\"not_following\",\"followers_max\":350,\"following_max\":200,\"orderby\":\"last_tweeted\"}";
            sourceTwo =
                @"https://community.statusbrew.com/twitter/1246601462/source/b88d4bde98cb615bdb9afe3f9ede9a59#activity/{" +
                "\"request_type\":\"followers\",\"exclude_pf\":true,\"has_avatar\":1,\"filter_graph\":\"not_following\",\"followers_max\":350,\"following_max\":200,\"orderby\":\"last_tweeted\"}";
            sourceThree =
                "https://community.statusbrew.com/twitter/1246601462/source/5f68a3051ee23d81299d6064e1f679a1#activity/{" +
                "\"request_type\":\"followers\",\"exclude_pf\":true,\"has_avatar\":1,\"filter_graph\":\"not_following\",\"followers_max\":350,\"following_max\":200,\"orderby\":\"last_tweeted\"}";
            sourceFour =
                @"https://community.statusbrew.com/twitter/1246601462/source/bb1831e96336d3313f64fa9a1b106958#activity/{" +
                "\"request_type\":\"followers\",\"exclude_pf\":true,\"has_avatar\":1,\"filter_graph\":\"not_following\",\"followers_max\":350,\"following_max\":200,\"orderby\":\"last_tweeted\"}";
            sourceFive =
                @"https://community.statusbrew.com/twitter/1246601462/source/bb1831e96336d3313f64fa9a1b106958#activity/{" +
                "\"request_type\":\"followers\",\"exclude_pf\":true,\"has_avatar\":1,\"filter_graph\":\"not_following\",\"followers_max\":350,\"following_max\":200,\"orderby\":\"last_tweeted\"}";
            sourceUnfollow = "https://community.statusbrew.com/twitter/1246601462#activity/{" +
                             "\"request_type\":\"nfb\",\"exclude_rf_days\":5,\"filter_graph\":\"following\",\"orderby\":\"last_tweeted\",\"orderdir\":\"asc\"}";
            }
        }
    }
