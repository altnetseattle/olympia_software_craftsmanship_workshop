# Getting The System Under Test

### Agenda
Pretty much speaks for itself.

### The Value Of Testing
* Fundamentally, testing provides an assurance that implementation of the deliverables conforms to some set of expactations across a variety of areas: Functional/technical concerns (do pages load?), Business needs (does it do what we want it to?), etc
* Automated testing does this, with some caveats:
  * Your tests are going to only be as good as your team
  * Tests are not "fire-and-forget", they introduce a maintenance burden
  * Don't aim to use automated testing to eliminate the need for other kinds of testing.. think of it as "enhancing" the other components of your test effort, freeing those resources up for more productive work.

### An overview of the entire test effort
* Unit Tests -- These are low-level tests, with each test or set of tests targetting a narrowly-focused subset of the system under test. Mock/stub everything else. Most of classical TDD happens in this space. These tests are purely code-focused.
  * Example -- We have a class with some business behavior in it. We write tests against this class to verify the expectations of the behavior in it.
  * Risks
    * Intention-revealing -- Your unit tests should be the first place another team member comes to look when they want to learn how the module you're implementing works. This means that your unit tests, much like your implementation itself, need to be intention-revealing and concise. The concerns associated with attaining this balance could span several day-long workshops.
	* Pervasive mocking -- its easy to go crazy once you get introduced to a mocking framework. its a matter of self-restraint to keep your tests from become tests of how mockable your code is, as opposed to testing the validity of your business rules.
* Integration Tests -- These are tests that are focused on integration of disparate parts of the system. Typically, things aren't mocked/stubbed at this layer, but un-used systems may be mocked/stubbed as-needed.
  * Example -- Tests that verify queries against the database or Application-to-Database wiring.
  * Risks
    * Perf -- tests that hit the database run much longer than those that don't, usually. This adds up once you get into the hundreds of tests.
	* Its easy and sometimes neccessary to write lots of tests that should be unit tests, but let them have integration-like behavior (access to the db, mostly). This is a big risk due to the perf issue mentioned above. Be vigilant about avoiding this unless absolutely neccessarily.  
* End-To-End Tests -- These are tests that happen in the context of a "production-like" environment. They are meant to shake out any last minute issues in a near-totally integrated environment. This is where the majority of web/UI testing happens in the classical case. There is a temptation to let this layer house the "business rule" verification (ex: fit style tests), but it can be a risky proposition because the UI layer has the most cruft and "distance" between it and the actual domain. The UI is also the most brittle placee to do business rule verification.
  * Example -- Web tests in the typical web-software stack.
  * Risks
    * See the perf issues discussed w/r/t Integration Tests.

Furthermore, note that it's a test *pyramid* (it get's narrower towards the top). This represents the relative risk of each layer in terms of test maint. burden, performance of test suites, theoretical brittleness, etc. Heed the warning this pyramid represents, lest you find yourself in the Zone of Pain.

### "Outside-in" Testing
It's a way to "bootstrap" the automated testing effort. Going off of the idea that "any tests are better than no tests", it aims to get your system under test (and give you some peace-of-mind that things are doing what they should) by painting with as broad a strokes as possible.

It's a *temporary* solution that should, responsibly, be replaced with more thoughtfully designed and employed tests at some time in the future (post-refactor).

If these tests start out as the stop-gap measure that ends up becoming permanent, you *will* feel the pain. The same way that anyone who has a business critical process that depends on one member of the team who decides to leave the company, gets hit by a bus, etc feels the pain when one of these scenarios happens.

These tests provide a great place to start, but eventually your system needs to grow into accomadating a more mature test suite that is equal parts business-behavior-verifying, sustainable and performant. Fixing these tests is considered "paying down a design debt"

### The Hasty Fighting Position As A Metaphor For Outside-in Testing
The Hasty Fighting Position (aka the Ranger Grave) is a US Army Light Infantry doctrinal approach to allow soldiers to quickly "dig-in" and establish a lightly fortified position to be defended for ~48 hours or less. After that, they need to either bug out or build better fighting positions (pay their design debt).

It has the following characteristics:
* Provides some cover and concealment from the enemy
* Meant to accomadate teams, but can be made solo (usually working in teams of two, one soldier digs while the other pulls security)
* perhaps most importantly, it quick and easy to make and pays dividends immediately. Kneeling better than standing, prone better than kneeling, ranger graves are better than just laying in the dirt.

Outside-in testing is like this. It's a "black-box" approach to testing without much consideration paid to implementation details beyond those germaine to the test framework.

These tests typically end up living in the end-to-end test layer.

### Let's Talk Tools
* WatiR -- Open source, ruby-based solution for manipulating a web browser in order to compose web tests. Has a recorder. Uses COM for IE manip. Does it support other browsers? Never used it, personally, but it is highly regarded in the  WatiN -- Open source, .NET framework for browser manipulation. Uses COM for IE manipulation and has tentative Firefox 3.0+ support via a javascript plugin for the browser. Has a recorder. Anecdotal poor perf, but a rich API.
* MSTest/MS Web Testing -- Released with Visual Studio Test Edition in 2005+. Has seperate licensing regime for "test agents" to run tests. Has a "headless", synthetic browser that mocks the capabilities of Internet Explorer. Seems to only target IE in various versions. Is also perf-testing oriented (hence the agent nodes). Overall, a very VS-centric solution that is only feasible for larger teams with the money for the MSDN licenses, but provides a much-sought-after perf testing capability. Very large service-oriented IT companies (HP, IBM), have epically huge server farms and charge (literally) thousands of dollars an hour for their perf testing capabilities.
* Selenium -- Open Source, javascript-manipulation-based solution that supports Firefox (2, 3+), Internet Explorer, Safari and recently added support for Google Chrome. It can either be used to compose tests with a Firefox plugin (Selenium IDE) or allow composing tests in a number of different languages/platforms (ruby, python, Objective-C, .NET, Java, etc), which are then executed against a Java server (Selenium/RC), which then does the job of launching/manipulating the browser.

### A Bit More On Selenium
* When to use SeleniumIDE versus Selenium/RC plus API
  * SeleniumIDE 
    * Very easy to get bootstrapped with. You can quickly prototype tests in a more "visual" fashion. 
	* It is easy to use to adapt/automate test scripts. 
	* It's not really scalable and offers no reusability out of the box. 
    * It can store your code as HTML (the native format for SeleniumIDE "test cases", as they're known individidually) or emit code in the various languages covered by the test API (python, c#, etc).
    * .. but the test code could very well be useless if you compose your code-based tests using any kind of reusability API (Page wrappers, particularly).
	* tends to locate elements by very-brittle xpath when used with the auto-recorder.
	* bottom line: best suited to use when "just getting started" or if you need to quickly spin up a set of throw-away tests
  * Selenium/RC + API
    * the tests are written as code (may be a good thing or a bad thing, depending on your perspective)
	* not as accessible to compose, compared to SeleniumIDE
	* need to use a pattern (page wrappers, once again) to make them 1) easier to write, 2) scalable and 3) maintainable.
	* need to learn the specifics of Selenium's API with regard to Locators (xpath, css, etc)..
	* bottom line: a higher learning curve, but ultimately the most responsible choice, longterm, for creating a sustainable suite of web tests

### What's All This Talk Of Sustainability?
* Ultimately, you're gonna put yourself in a difficult position if you grow a large suite of hastilly designed outside-in tests and keep them for long-term use.
* Thusly, the most-responsible thing to do when creating a suite of web tests would be to think long and hard about the approach you want to use. The breadth of this topic is beyond the scope of this presentation.

### Looping Back To Outside-In Testing...
These kinds of tests break down into two groups:
* Queries -- represents just going to a page and verifying that some information is present.
* Commands -- actually executing some work flow and verifying a desired result	

### ... And The Value Of Test Data
* You obviously need *some kind* of a test data to drive your application while in test. For a team just starting out, this will most likely be a copy of production, if possible.
* Ultimately, you'll want to 'trim' that data profile down to the *bare minimum* neccesary for your application's various pages to load without throwing exceptions.
* Atop this, you'll want to build up a suite of test data "scenarios" to flesh out various needs for your test-suite.
* Examples
* everything that's required to have an easily deployable set of data scenarios is, sadly, outside of the scope of this presentation

### Let's Do Some Web Tests
the script:
* quickly demo in the functionality of the SUFORS site in the context of creating some outside-in tests
* (maybe?) mention what is missing, functionality-wise (editing citizens, tying orphaned reports to citizens, paging, etc)
* show selenium IDE and demonstrate the various parts of it...
* do the "hello world" test to verify that the app doesn't barf when we try to load the home page and talk about what this gets you in terms of testing
* do the test for verifying that the citizens list loads.. 
  * talk about the various ways to assert that this passes...
* do the test for adding a new citizen
  * talk about concerns for how to assert on it.. 
  * demo the issues with click vs. clickAndWait()
  * talk about the speed of tests
* same for the test to add a report to a citizen