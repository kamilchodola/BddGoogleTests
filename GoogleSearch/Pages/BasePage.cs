using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleSearch.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver { get; }

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
