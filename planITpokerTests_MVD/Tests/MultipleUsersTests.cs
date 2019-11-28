using _01_planITpoker_clas_library_tests;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using planITpokerTests_MVD.Pages;
using System;
using System.Linq;
using Xunit;

namespace planITpokerTests_MVD.Tests
{
    public class MultipleUsersTests : IDisposable
    {
        IWebDriver driver;
        IWebDriver driver2;
        public MultipleUsersTests()
        {
            this.driver = new FirefoxDriver();
        }
        [Fact]
        public void UserInvitedByInviteLink()
        {
            var home = new HomePage(driver);
            var game = home.MultipleUserQuickPlayGame("Jack", "Test Room", "Test Story", "Test Story 2");
            string website = game.InviteLink;
            driver.Quit();
            driver2 = new FirefoxDriver();
            var uHome = new QuickPlayPage(driver2, website);
            var uGame = uHome.JoinQuickPlay("John");
            Assert.Equal("Test Room", uGame.RoomName);
        }
        [Fact]
        public void UserCanSeeOthersVotesOnlyAfterVoting()
        {
            var home = new HomePage(driver);
            var game = home.MultipleUserQuickPlayGame("Jack", "Test Room", "Test Story", "Test Story 2");
            game.Start();
            game.Vote(1);
            string website = game.InviteLink;
            driver2 = new FirefoxDriver();
            var uHome = new QuickPlayPage(driver2, website);
            var uGame = uHome.JoinQuickPlay("John");
            uGame.Vote(2);
            //asserts that after the second user has voted, he can see the first user's vote
            Assert.Equal("1", game.VoteValueOne);            
        }
        [Fact]
        public void NewUserJoinAndVoteAfterVotingStarts()
        {
            var home = new HomePage(driver);
            var game = home.MultipleUserQuickPlayGame("Jack", "Test Room", "Test Story", "Test Story 2");
            game.Start();
            game.Vote(1);
            string website = game.InviteLink;
            driver2 = new FirefoxDriver();
            var uHome = new QuickPlayPage(driver2, website);
            var uGame = uHome.JoinQuickPlay("John");
            uGame.Vote(2);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Assert.Equal("2", game.VoteValueTwo);
        }
        [Fact]
        public void ModeratorCanFinishVotingOnlyAfterAllUsersVoted()
        {
            var home = new HomePage(driver);
            var game = home.MultipleUserQuickPlayGame("Jack", "Test Room", "Test Story", "Test Story 2");
            game.Start();
            game.Vote(1);
            string website = game.InviteLink;
            driver2 = new FirefoxDriver();
            var uHome = new QuickPlayPage(driver2, website);
            var uGame = uHome.JoinQuickPlay("John");
            uGame.Vote(2);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Assert.NotNull(game.FinishVotingButton);
        }
        [Fact]
        public void ModeratorCanRemovePlayer()
        {
            var home = new HomePage(driver);
            var game = home.MultipleUserQuickPlayGame("Jack", "Test Room", "Test Story", "Test Story 2");
            string website = game.InviteLink;
            driver2 = new FirefoxDriver();
            var uHome = new QuickPlayPage(driver2, website);
            var uGame = uHome.JoinQuickPlay("John");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            game.ClickPlayerTwoAvatar();
            game.RemoveUser();
            Assert.True(game.PlayerList);
        }
        [Fact]
        public void DeAssignRoleOfModerator()
        {
            var home = new HomePage(driver);
            var game = home.MultipleUserQuickPlayGame("Jack", "Test Room", "Test Story", "Test Story 2");
            string website = game.InviteLink;
            driver2 = new FirefoxDriver();
            var uHome = new QuickPlayPage(driver2, website);
            var uGame = uHome.JoinQuickPlay("John");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            game.ClickPlayerTwoAvatar();
            game.ClickModeratorRole();
            game.ClickPlayerOneAvatar();
            game.ClickModeratorRole();
            //first player is Jack who makes the room and is moderator (and is the first in the player name list)
            //Jack makes John the moderator and then de-assigns himself as moderator
            //now Jack is second in the player name list
            Assert.Equal("Jack", game.PlayerTwoName);
        }
        [Fact]
        public void ObserverSeesPlayersVotingInRealTime()
        {
            var home = new HomePage(driver);
            var game = home.MultipleUserQuickPlayGame("Jack", "Test Room", "Test Story", "Test Story 2");
            game.Start();
            game.Vote(1);
            string website = game.InviteLink;
            driver2 = new FirefoxDriver();
            var uHome = new QuickPlayPage(driver2, website);
            var uGame = uHome.JoinQuickPlay("John");
            uGame.ClickPlayerTwoAvatar();
            uGame.ClickObserverRole();
            Assert.NotEqual("00:00:00", uGame.Timer);
            Assert.Equal("1", game.VoteValueOne);
        }
        public void Dispose()
        {
            driver.Quit();
            driver2.Quit();
        }
    }
}
