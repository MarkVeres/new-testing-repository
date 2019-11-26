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

namespace _01_planITpoker_clas_library_tests.Pages
{
    public class GamePage
    {
        IWebDriver driver;
        WebDriverWait wait;
        By createStory = By.CssSelector(".create-story-textarea > div:nth-child(1) > div:nth-child(1) > textarea:nth-child(1)");
        By saveAndAddNewStory = By.CssSelector("div.margin-bottom:nth-child(1) > button:nth-child(1)");
        By saveCloseButton = By.CssSelector("div.margin-bottom:nth-child(2) > button:nth-child(1)");
        By endTour = By.CssSelector("button.btn:nth-child(3)");
        By timer = By.CssSelector(".timer > div:nth-child(1) > span:nth-child(2)");
        By userPlayers = By.CssSelector(".players-text");
        By startButton = By.CssSelector("#btn-start");
        By skipStory = By.CssSelector(".controls > div:nth-child(1) > div:nth-child(4) > button:nth-child(1)");
        By nextStoryButton = By.CssSelector(".controls > div:nth-child(1) > div:nth-child(4) > button:nth-child(1)");
        By card1 = By.CssSelector("li.ng-scope:nth-child(3) > button:nth-child(1) > div:nth-child(2)");
        By card2 = By.CssSelector(".cards > li:nth-child(4) > button:nth-child(1) > div:nth-child(2)");
        By storyTitleName = By.CssSelector(".story-title-inner");
        By storyListName = By.XPath("/html/body/div[1]/div/div[1]/div/div/section/div/div[2]/div[2]/div[1]/section/div/div[1]/div/div/div/div[1]/table/tbody/tr[1]/td[1]");
        By storyListName2 = By.XPath("/html/body/div[1]/div/div[1]/div/div/section/div/div[2]/div[2]/div[1]/section/div/div[1]/div/div/div/div[1]/table/tbody/tr[2]/td[1]");
        By voteValue = By.CssSelector("span.ng-scope:nth-child(3) > span:nth-child(1)");
        By finishVoting = By.CssSelector(".control1 > div:nth-child(1) > div:nth-child(2) > button:nth-child(1)");
        By pieChart = By.CssSelector(".ct-chart-donut");
        By clearVotes = By.CssSelector(".controls > div:nth-child(1) > div:nth-child(3) > button:nth-child(1)");
        By toastError = By.ClassName("toast-message");
        By account = By.CssSelector("a.dropdown-toggle");
        By accountRooms = By.CssSelector("li.collapsed:nth-child(4) > a:nth-child(1)");
        By avatar = By.CssSelector(".img-border > img:nth-child(3)");
        By avatarObserver = By.CssSelector(".open > ul:nth-child(2) > li:nth-child(3) > a:nth-child(1)");
        By deleteStoryButton = By.ClassName("btn-delete-icon");
        By exportStories = By.CssSelector(".open > ul:nth-child(2) > li:nth-child(1) > a:nth-child(1)");
        By estimates = By.Id("finalEstimate");
        By estimatesOne = By.CssSelector("option.ng-binding:nth-child(3)");
        By estimatesForty = By.CssSelector("option.ng-binding:nth-child(10)");
        By completedStoriesTab = By.CssSelector("section.stories-list:nth-child(2) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > ul:nth-child(1) > li:nth-child(2) > a:nth-child(1) > span:nth-child(1)");
        By toastMessage = By.CssSelector("#toast-container");
        //By playerOneAvatar = By.CssSelector("div.player:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1)");
        //By playerTwoAvatar = By.CssSelector("div.player:nth-child(2) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1)");
        //By moderatorRole = By.CssSelector(".open > ul:nth-child(2) > li:nth-child(1) > a:nth-child(1)");

        public GamePage(IWebDriver driver, WebDriverWait wait)
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
        public string EndTour  //used for DissallowStoryCreation Test Assert
        {
            get
            {
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(endTour)).Text;
            }
        }
        public string Players   //used for CreateRoom-(RoomCreationTests) test Assert
        {
            get
            {
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(userPlayers)).Text;
            }
        }
        public string Report  //used for CreateStoryReport Test Assert
        {
            get
            {
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(exportStories)).Text;
            }
        }
        public string Timer  //used for TimeTheVoteProcess & UseCountDownTimer Test Assert
        {
            get
            {
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(timer)).Text;
            }
        }
        public string StoryName  //used for CreatingStory Test Assert
        {
            get
            {
                return driver.FindElement(storyTitleName).Text;
            }
        }
        public string StoryListName   //used for EditCreatedStories test Assert
        {
            get
            {
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(storyListName)).Text;
            }
        }
        public string StoryListName2  //used for DeleteCreatedStories Test Assert
        {
            get
            {
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(storyListName2)).Text;
            }
        }
        public string FinalEstimate   //used for SendingEstimates Test Assert
        {
            get
            {
                return driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div/section/div/div[2]/div[2]/div[1]/section/div/div[1]/div/div/div/div[2]/div[1]/table/tbody/tr[1]/td[2]")).Text;
            }
        }
        public string FinalEstimateSortBy  //used for SortingStories Test Assert
        {
            get
            {
                return driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div/section/div/div[2]/div[2]/div[1]/section/div/div[1]/div/div/div/div[2]/div[1]/table/tbody/tr[1]/td[2]")).Text;
            }
        }
        public string Votes  //used for VotingInGameRoom & AllowChangingVoteOption Test Assert
        {
            get
            {
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(voteValue)).Text;
            }
        }
        public string ToastError  //used for VotingTwiceOnSameStory & Observer cannot vote Test Assert
        {
            get
            {
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(toastError)).Text;
            }
        }
        public string NextStory  //used for SkipStory Test Assert
        {
            get
            {
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(nextStoryButton)).Text;
            }
        }
        public IWebElement ModeratorRole  //used for RoomCreatorShouldBeModerator Test Assert
        {
            get
            {
                return driver.FindElement(By.CssSelector(".moderator > i:nth-child(1)"));
            }
        }
        public GamePage CreateStory(string inputStory, string inputStory2)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(createStory)).SendKeys(inputStory);
            driver.FindElement(saveAndAddNewStory).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(createStory)).SendKeys(inputStory2);
            driver.FindElement(saveCloseButton).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(endTour)).Click();
            var game = new GamePage(driver, wait);
            return game;
        }
        public GamePage Start()
        {
            driver.FindElement(startButton).Click();
            var game = new GamePage(driver, wait);
            return game;
        }
        public GamePage Vote(int num)
        {
            string card = Convert.ToString(num);
            var cardsList = driver.FindElements(By.CssSelector(".cards li button"));
            var selectedCard = cardsList.First(e => e.FindElement(By.TagName("div")).Text == card);
            selectedCard.Click();
            var game = new GamePage(driver, wait);
            return game;
        }
        public GamePage FinishVoting()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(finishVoting)).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(pieChart));
            var game = new GamePage(driver, wait);
            return game;
        }
        public GamePage ClearVotes()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(clearVotes)).Click();
            var game = new GamePage(driver, wait);
            return game;
        }
        public GamePage Vote1AfterCountdownEnds()
        {
            Thread.Sleep(32000);
            driver.FindElement(card1).Click();
            var game = new GamePage(driver, wait);
            return game;
        }
        public GamePage VoteAndSendEstimates()
        {
            //votes 1 and estimate = 1 on first question and votes 2 and estimate = 2 on second question
            //also clicks toast messages so they dissapear faster in order to be able to click certain buttons
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(startButton)).Click();
            driver.FindElement(toastMessage).Click();
            driver.FindElement(card1).Click();
            driver.FindElement(toastMessage).Click();
            driver.FindElement(estimates).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(estimatesOne)).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(finishVoting)).Click();
            driver.FindElement(toastMessage).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(nextStoryButton)).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(card2)).Click();
            driver.FindElement(estimates).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(estimatesForty)).Click();
            driver.FindElement(finishVoting).Click();
            var game = new GamePage(driver, wait);
            return game;
        }
        public GamePage ScrollDownSeeStoryDetails()
        {
            var scroll = new ScrollIntoView(driver);
            scroll.ScrollDown();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(completedStoriesTab)).Click();
            var game = new GamePage(driver, wait);
            return game;
        }
        public GamePage SortStoriesByFinalEstimate()
        {
            driver.FindElement(By.ClassName("btn-edit")).Click();
            driver.FindElement(By.CssSelector(".open > ul:nth-child(2) > li:nth-child(2) > a:nth-child(1)")).Click();
            driver.FindElement(By.CssSelector("div.customize-story-row:nth-child(3) > div:nth-child(1) > label:nth-child(1) > span:nth-child(1)")).Click();
            driver.FindElement(By.CssSelector("div.row:nth-child(5) > div:nth-child(1) > button:nth-child(1)")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(completedStoriesTab));
            var game = new GamePage(driver, wait);
            return game;
        }
        public GamePage SkipStory()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(skipStory)).Click();
            driver.SwitchTo().Alert().Accept();
            //set to wait until Skip Story Alert is accepted and Pie Chart is Visible so that Skip Story button goes -> Processing -> Next Story
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(pieChart));
            var game = new GamePage(driver, wait);
            return game;
        }
        public RoomsPage GoToRoomsPage()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(account)).Click();
            driver.FindElement(accountRooms).Click();
            var room = new RoomsPage(driver, wait);
            return room;
        }
        public GamePage ClickAvatar()
        {
            driver.FindElement(avatar).Click();
            var game = new GamePage(driver, wait);
            return game;
        }
        public GamePage ChangeRoleObserver()
        {
            driver.FindElement(avatar).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(avatarObserver)).Click();
            var game = new GamePage(driver, wait);
            return game;
        }
        public GamePage EditStories(string editedStory)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(startButton));
            var scroll = new ScrollIntoView(driver);
            scroll.ScrollDown();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(storyListName)).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("input.ng-scope"))).Clear();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("input.ng-scope"))).SendKeys(editedStory);
            driver.FindElement(By.CssSelector("div.in:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(2) > div:nth-child(3) > div:nth-child(1)")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(storyListName));
            var game = new GamePage(driver, wait);
            return game;
        }
        public GamePage DeleteStory()
        {
            var scroll = new ScrollIntoView(driver);
            scroll.ScrollDown();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(deleteStoryButton)).Click();
            driver.SwitchTo().Alert().Accept();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(storyListName));
            var game = new GamePage(driver, wait);
            return game;
        }
        public GamePage GetReport()
        {
            var scroll = new ScrollIntoView(driver);
            scroll.ScrollDown();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName("btn-edit"))).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(exportStories));
            var game = new GamePage(driver, wait);
            return game;
        }
        //public GamePage ClickPlayerOneAvatar()
        //{
        //    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(playerOneAvatar)).Click();
        //    var game = new GamePage(driver, wait);
        //    return game;
        //}
        //public GamePage ClickPlayerTwoAvatar()
        //{
        //    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(playerTwoAvatar)).Click();
        //    var game = new GamePage(driver, wait);
        //    return game;
        //}
        //public GamePage AssignModeratorRole()
        //{
        //    driver.FindElement(moderatorRole).Click();
        //    var game = new GamePage(driver, wait);
        //    return game;
        //}
    }
}
