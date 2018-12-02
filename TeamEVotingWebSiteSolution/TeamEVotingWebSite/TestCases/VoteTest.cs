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
    public class VoteTest
    {
        IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void CreateUserTest()
        {
            int startVotes = 0;
            int endVotes = 0;

            using (TeamEVotingDBEntities teamEVotingDBEntities = new TeamEVotingDBEntities()) // find the amount of votes before voting
            {
                CandidateSet cs = teamEVotingDBEntities.CandidateSet.Where(x => x.Candidate_Id == 7).FirstOrDefault();
                startVotes = (int)cs.NumberOfVotes;
            }

            driver.Url = "https://teamevotingwebsite.azurewebsites.net/";
            driver.FindElement(By.XPath("//a[@href='/Users/Create']")).Click();
            

            IWebElement firstName = driver.FindElement(By.Id("User_FirstName"));
            firstName.SendKeys("TestFirstName");

            IWebElement lastName = driver.FindElement(By.Id("User_LastName"));
            lastName.SendKeys("TestLastName");

            SelectElement candidate = new SelectElement(driver.FindElement(By.Id("Candidate_Id")));
            candidate.SelectByText("test test");

            driver.FindElement(By.CssSelector(".btn.btn-default")).Click(); // vote for test candidate

            using (TeamEVotingDBEntities teamEVotingDBEntities = new TeamEVotingDBEntities()) // find the amount of votes after voting
            {
                CandidateSet cs = teamEVotingDBEntities.CandidateSet.Where(x => x.Candidate_Id == 7).FirstOrDefault();
                endVotes = (int)cs.NumberOfVotes;
            }

            Assert.Greater(endVotes, startVotes); // check if voting was successful
        }

        [TearDown]
        public void EndTest()
        {
            driver.Close();
        }
    }
}