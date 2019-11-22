using _01_planITpoker_clas_library_tests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planITpokerTests_MVD.Pages
{
    public class OtherUserPage
    {
        IWebDriver driver;
        WebDriverWait wait;
        By userName = By.CssSelector(".form-control");
        By enterButton = By.CssSelector("button.btn");
        By roomName = By.CssSelector(".page-header");

        public OtherUserPage(IWebDriver driver, string website)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.Url = website;
        }
        public GamePage JoinGame(string inputName)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(userName)).SendKeys(inputName);
            driver.FindElement(enterButton).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(roomName));
            GamePage game = new GamePage(driver, wait);
            return game;
        }
    }
}
