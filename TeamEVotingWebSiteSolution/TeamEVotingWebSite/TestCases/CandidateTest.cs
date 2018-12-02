using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TeamEVotingWebSite.TestCases
{
    public class CandidateTest
    {
        IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void CreateCandidateTest()
        {
            driver.Url = "https://teamevotingwebsite.azurewebsites.net/";
            driver.FindElement(By.XPath("//a[@href='/Candidates/Index']")).Click();
            driver.FindElement(By.XPath("//a[@href='/Candidates/Create']")).Click();

            IWebElement firstName = driver.FindElement(By.Id("Candidate_FirstName"));
            firstName.SendKeys("TestFirstName");

            IWebElement lastName = driver.FindElement(By.Id("Candidate_LastName"));
            lastName.SendKeys("TestLastName");

            IWebElement age = driver.FindElement(By.Id("Candidate_Age"));
            age.Clear();
            age.SendKeys("30");

            SelectElement region = new SelectElement(driver.FindElement(By.Id("Region_Id")));
            region.SelectByIndex(1);

            SelectElement faction = new SelectElement(driver.FindElement(By.Id("Faction_Id")));
            faction.SelectByIndex(1);

            driver.FindElement(By.CssSelector(".btn.btn-default")).Click();

            IList<IWebElement> deleteButtons = driver.FindElements(By.CssSelector("[href^='/Candidates/Delete/']"));

            deleteButtons.Last().Click();

            driver.FindElement(By.CssSelector(".btn.btn-default")).Click();
        }

        [TearDown]
        public void EndTest()
        {
            driver.Close();
        }
    }
}