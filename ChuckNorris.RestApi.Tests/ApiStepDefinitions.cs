using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace ChuckNorris.RestApi.Tests
{

    [Binding]
    public class ApiStepDefinitions
    {
        private ScenarioContext context;

        public ApiStepDefinitions(ScenarioContext context)
        {
            this.context = context;
        }

        [Given(@"a Boomer")]
        public void GivenABoomer()
        {
            var client = new RestClient("https://api.chucknorris.io/jokes/");
            context.Set(client);
        }

        [When(@"the Boomer asks for a random Chuck Norris fact")]
        public async Task WhenTheBoomerAsksForARandomChuckNorrisFact()
        {
            var client = context.Get<RestClient>();
            var response = await client.GetJsonAsync<JokeResource>("random");
            context.Set(response);
        }

        [Then(@"the fact must contain the words ""([^""]*)""")]
        public void ThenTheFactMustContainTheWords(string term)
        {
            var response = context.Get<JokeResource>();
            Assert.Contains(term, response.value);
        }

        [When(@"the Boomer asks for Chuck Norris facts that mention Jason Statham")]
        public async Task WhenTheBoomerAsksForChuckNorrisFactsThatMentionJasonStatham()
        {
            var client = context.Get<RestClient>();
            var response = await client.GetJsonAsync<JokeResourceCollection>("search?query=statham");
            context.Set(response);
        }

        [Then(@"there will be no facts")]
        public void ThenThereWillBeNoFacts()
        {
            var response = context.Get<JokeResourceCollection>();
            Assert.Equal(0, response.total);
        }
    }
}
