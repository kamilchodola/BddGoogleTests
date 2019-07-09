using GoogleSearch.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace GoogleSearch.Steps
{
    [Binding]
    public class GoogleSearchTestSteps : BaseSteps
    {
        [Given(@"I have entered '(.*)' into the search textbox")]
        public void GivenIHaveEnteredIntoTheSearchTextbox(string searchText)
        {
            MainPage mainPage = new MainPage(Driver);
            mainPage.SetSearchTextBox(searchText);
        }

        [When(@"I press search button")]
        public void WhenIPressSearchButton()
        {
            MainPage mainPage = new MainPage(Driver);
            mainPage.ClickSearchButton();
        }

        [Then(@"the result should be '(.*)' on the location textbox")]
        public void ThenTheResultShouldBeOnTheLocationTextbox(string locationString)
        {
            ResultsPage resultsPage = new ResultsPage(Driver);
            Assert.AreEqual(locationString, resultsPage.GetCompanyAddress(), "Given company address not match with address on Google.");
        }

        [Then(@"the result should be '(.*)' as a first result")]
        public void ThenTheResultShouldBeAsAFirstResult(string url)
        {
            ResultsPage resultsPage = new ResultsPage(Driver);
            var searchResults = resultsPage.GetResultsList();
            Assert.AreEqual(url, resultsPage.GetUrl(searchResults.First()), "First search result is not valid.");
        }

        [Then(@"the result should be '(.*)' and '(.*)' in top (.*) results of searching")]
        public void ThenTheResultShouldBeAndInTopResultsOfSearching(string firstUrl, string secondUrl, int numberOfTopItems)
        {
            ResultsPage resultsPage = new ResultsPage(Driver);
            var searchResults = resultsPage.GetResultsList();
            var topResultsUrls = searchResults.Take(numberOfTopItems).Select(x => resultsPage.GetUrl(x)).ToList();
            CollectionAssert.Contains(topResultsUrls, firstUrl, $"There is no url like {firstUrl} in top {numberOfTopItems} results");
            CollectionAssert.Contains(topResultsUrls, secondUrl, $"There is no url like {secondUrl} in top {numberOfTopItems} results");
        }
    }
}
