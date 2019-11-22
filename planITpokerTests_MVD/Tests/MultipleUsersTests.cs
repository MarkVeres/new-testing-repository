using _01_planITpoker_clas_library_tests;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using planITpokerTests_MVD.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace planITpokerTests_MVD.Tests
{
    public class MultipleUsersTests : IDisposable
    {
        IWebDriver driver;
        public MultipleUsersTests()
        {
            this.driver = new FirefoxDriver();
        }
        [Fact]
        public void UserInvitedByInviteLink()
        {
            var home = new HomePage(driver);
            var game = home.QuickPlayGame("Jack", "Test Room", "Test Story", "Test Story 2");
            string website = game.InviteLink;
            driver.Quit();
            driver = new FirefoxDriver();
            var uHome = new OtherUserPage(driver, website);
            var uGame = uHome.JoinGame("John");
            Assert.Equal("Test Room", uGame.RoomName);
        }
        public void Dispose()
        {
            driver.Quit();
        }
    }
}
