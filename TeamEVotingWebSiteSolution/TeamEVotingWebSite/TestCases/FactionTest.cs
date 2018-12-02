using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TeamEVotingWebSite.Models;

namespace TeamEVotingWebSite.TestCases
{
    public class FactionTest
    {
        IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void CreateFactionTest()
        {
            driver.Url = "https://teamevotingwebsite.azurewebsites.net/";
            driver.FindElement(By.XPath("//a[@href='/Factions/Index']")).Click();
            driver.FindElement(By.XPath("//a[@href='/Factions/Create']")).Click();

            IWebElement firstName = driver.FindElement(By.Id("Faction_Name"));
            firstName.SendKeys("TestFaction");

            driver.FindElement(By.CssSelector(".btn.btn-default")).Click(); // create a new faction

            using (TeamEVotingDBEntities teamEVotingDBEntities = new TeamEVotingDBEntities()) // check if creation was successful
            {
                List<FactionSet> factions = teamEVotingDBEntities.FactionSet.ToList();
                FactionSet fs = factions.Last();

                StringAssert.Contains("TestFaction", fs.Faction_Name);
            }

            IList<IWebElement> deleteButtons = driver.FindElements(By.CssSelector("[href^='/Factions/Delete/']"));

            deleteButtons.Last().Click();

            driver.FindElement(By.CssSelector(".btn.btn-default")).Click(); // delete the created faction

            using (TeamEVotingDBEntities teamEVotingDBEntities = new TeamEVotingDBEntities()) // check if deletion was successful
            {
                List<FactionSet> factions = teamEVotingDBEntities.FactionSet.ToList();
                FactionSet fs = factions.Last();

                StringAssert.DoesNotContain("TestFaction", fs.Faction_Name);
            }
        }

        [TearDown]
        public void EndTest()
        {
            driver.Close();
        }
    }
}