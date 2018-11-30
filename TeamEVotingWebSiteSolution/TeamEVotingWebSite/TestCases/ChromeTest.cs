using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TeamEVotingWebSite
{
    public class ChromeTest
    {
        IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void OpenChromeTest()
        {
            driver.Url = "https://teamevotingwebsite.azurewebsites.net/";
        }

        [TearDown]
        public void EndTest()
        {
            driver.Close();
        }
    }
}