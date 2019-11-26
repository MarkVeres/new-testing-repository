using _01_planITpoker_clas_library_tests.Tests;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace planITpokerTests_MVD.Pages
{
    public class MultipleUserGamePage
    {
        IWebDriver driver;
        WebDriverWait wait;
        By startButton = By.CssSelector("#btn-start");
        By voteValue = By.CssSelector("span.ng-scope:nth-child(3) > span:nth-child(1)");
        By timer = By.CssSelector(".timer > div:nth-child(1) > span:nth-child(2)");
        By playerOneAvatar = By.CssSelector("div.player:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1)");
        By playerTwoAvatar = By.CssSelector("div.player:nth-child(2) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1)");
        By moderatorRole = By.CssSelector(".open > ul:nth-child(2) > li:nth-child(1) > a:nth-child(1)");
        By observerRole = By.CssSelector(".open > ul:nth-child(2) > li:nth-child(2) > a:nth-child(1)");
        By createStory = By.CssSelector(".create-story-textarea > div:nth-child(1) > div:nth-child(1) > textarea:nth-child(1)");
        By saveAndAddNewStory = By.CssSelector("div.margin-bottom:nth-child(1) > button:nth-child(1)");
        By saveCloseButton = By.CssSelector("div.margin-bottom:nth-child(2) > button:nth-child(1)");
        By endTour = By.CssSelector("button.btn:nth-child(3)");

        public MultipleUserGamePage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }
        public string InviteLink
        {
            get
            {
                return driver.FindElement(By.CssSelector("#invite-link")).GetAttribute("value").ToString();
            }
        }
        public string RoomName   //used for MultipleUsers Test Assert
        {
            get
            {
                return driver.FindElement(By.CssSelector(".page-header")).Text;
            }
        }
        public string Timer  //used for ObserverSeesPlayersVotingInRealTime Test Assert
        {
            get
            {
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(timer)).Text;
            }
        }
        public string PlayerTwoName
        {
            get
            {
                return driver.FindElement(By.CssSelector("div.player:nth-child(2) > div:nth-child(2) > div:nth-child(1) > span:nth-child(1)")).Text;
            }
        }
        public string Votes  //used for ObserverSeesPlayersVoteingInRealTime Test Assert
        {
            get
            {
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(voteValue)).Text;
            }
        }
        public MultipleUserGamePage CreateStory(string inputStory, string inputStory2)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(createStory)).SendKeys(inputStory);
            driver.FindElement(saveAndAddNewStory).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(createStory)).SendKeys(inputStory2);
            driver.FindElement(saveCloseButton).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(endTour)).Click();
            var game = new MultipleUserGamePage(driver, wait);
            return game;
        }
        public MultipleUserGamePage Start()
        {
            driver.FindElement(startButton).Click();
            var game = new MultipleUserGamePage(driver, wait);
            return game;
        }
        public MultipleUserGamePage Vote(int num)
        {
            string card = Convert.ToString(num);
            var cardsList = driver.FindElements(By.CssSelector(".cards li button"));
            var selectedCard = cardsList.First(e => e.FindElement(By.TagName("div")).Text == card);
            selectedCard.Click();
            var game = new MultipleUserGamePage(driver, wait);
            return game;
        }
        public MultipleUserGamePage ClickPlayerOneAvatar()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(playerOneAvatar)).Click();
            var game = new MultipleUserGamePage(driver, wait);
            return game;
        }
        public MultipleUserGamePage ClickPlayerTwoAvatar()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(playerTwoAvatar)).Click();
            var game = new MultipleUserGamePage(driver, wait);
            return game;
        }
        public MultipleUserGamePage ClickModeratorRole()
        {
            driver.FindElement(moderatorRole).Click();
            var game = new MultipleUserGamePage(driver, wait);
            return game;
        }
        public MultipleUserGamePage ClickObserverRole()
        {
            driver.FindElement(observerRole).Click();
            var game = new MultipleUserGamePage(driver, wait);
            return game;
        }
    }
}
