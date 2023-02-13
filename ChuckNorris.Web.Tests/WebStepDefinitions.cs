using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace ChuckNorris.Web.Tests
{
    [Binding]
    public class WebStepDefinitions
    {
        private ScenarioContext context;

        public WebStepDefinitions(ScenarioContext context)
        {
            this.context = context;
        }

        [Given(@"a Boomer")]
        public void GivenABoomer()
        {
            IWebDriver driver = new ChromeDriver();
            context.Set(driver);
        }

        [When(@"the Boomer asks for a random Chuck Norris fact")]
        public void WhenTheBoomerAsksForARandomChuckNorrisFact()
        {
            var driver = context.Get<IWebDriver>();
            driver.Navigate().GoToUrl("https://api.chucknorris.io/");
            driver.FindElement(By.CssSelector("[href*='/jokes/random']")).Click();
        }

        [Then(@"the fact must contain the words ""([^""]*)""")]
        public void ThenTheFactMustContainTheWords(string term)
        {
            var driver = context.Get<IWebDriver>();
            try
            {
                Assert.Contains(term, driver.PageSource);
            }
            finally
            {
                driver.Quit();
            }
        }

        [When(@"the Boomer asks for Chuck Norris facts that mention Jason Statham")]
        public void WhenTheBoomerAsksForChuckNorrisFactsThatMentionJasonStatham()
        {
            var driver = context.Get<IWebDriver>();
            driver.Navigate().GoToUrl("https://api.chucknorris.io/jokes/search?query=statham");
        }

        [Then(@"there will be no facts")]
        public void ThenThereWillBeNoFacts()
        {
            var driver = context.Get<IWebDriver>();
            try
            {
                Assert.DoesNotContain("statham", driver.PageSource);
            }
            finally
            {
                driver.Quit();
            }
        }

    }
}
