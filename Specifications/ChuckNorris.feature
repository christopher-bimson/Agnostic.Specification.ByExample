Feature: Chuck Norris Facts

In order to be entertained by stale meme humor
As a boomer
I want to get random Chuck Norris facts


Scenario: Random Chuck Norris Facts
	Given a Boomer
	When the Boomer asks for a random Chuck Norris fact
	Then the fact must contain the words "Chuck Norris"

Scenario: No-one cares about Jason Statham
	Given a Boomer
	When the Boomer asks for Chuck Norris facts about Jason Statham
	Then there should be no facts
