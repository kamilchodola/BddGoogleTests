using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoogleSearch.Locators;
using OpenQA.Selenium;

namespace GoogleSearch.Pages
{
    public class ResultsPage : BasePage
    {
        public IWebElement CompanyAddressLabel => Driver.FindElement(By.XPath("//div[@data-local-attribute='d3adr']/span[2]"));
        public IReadOnlyCollection<IWebElement> ResultsList => Driver.FindElements(By.ClassName("g"));
        public ResultsPage(IWebDriver driver) : base(driver)
        {
        }

        public string GetCompanyAddress()
        {
            return CompanyAddressLabel.Text;
        }

        public IReadOnlyCollection<IWebElement> GetResultsList()
        {
            return ResultsList;
        }

        public string GetUrl(IWebElement searchResultRow)
        {
            return searchResultRow.FindElement(SearchResultRowLocators.ResultUrl).GetAttribute("href");
        }
    }
}