using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace GoogleSearch.Pages
{
    public class MainPage : BasePage
    {
        public IWebElement SearchTextBox => Driver.FindElement(By.XPath("//input[@name='q']"));
        public IWebElement SearchButton => Driver.FindElement(By.XPath("//input[@name='btnK']"));

        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        public void SetSearchTextBox(string text)
        {
            SearchTextBox.SendKeys(text);
        }

        public void ClickSearchButton()
        {
            SearchButton.Click();
        }
    }
}
