using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace GoogleSearch.Steps
{
    public abstract class BaseSteps
    {
        protected IWebDriver Driver { get; }

        protected BaseSteps()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Driver.Navigate().GoToUrl("http://www.google.pl");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Driver.Quit();
        }
    }
}
