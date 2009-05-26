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
* Integration Tests -- These are tests that are focused on integration disparate parts of the system. Typically, things aren't mocked/stubbed at this layer, but un-used systems may be mocked/stubbed as-needed.
  * Example -- Tests that verify queries against the database or Application-to-Database wiring.
  * Risks
    * Perf -- tests that hit the database much longer than those that don't, usually. This adds up once you get into the hundreds.
	* Its easy and sometimes neccessary to write lots of tests that should be unit tests, but let them have integration like behavior (access to the db, mostly). This is a big risk due to the perf issue mentioned above. Be vigilant about avoiding this unless absolutely neccessarty.  
* End-To-End Tests -- These are tests that happen in the context of a "production-like" environment. They are meant to shake out any last minute issues in a near-totally integrated environment. This is where the majority of web/UI testing happens in the classical case. There is a temptation to let this layer house the "business rule" verification (ex: fit style tests), but it can be a risky proposition because the UI layer has the most cruft and "distance" between it and the actual domain. The UI is also the most brittle placee to do business rule verification.
  * Example -- Web tests in the typical web-software stack.
  * Risks
    * See the perf issues discussed w/r/t Integration Tests.

Furthermore, note that it's a test *pyramid* (it get's narrower towards the top). This represents the relative risk of each layer in terms of test maint. burden, performance of test suites, theoretical brittleness, etc. Heed the warning this pyramid represents, lest you find yourself in the Zone of Pain.

### "Outside-in" Testing
It's a way to "bootstrap" the automated testing effort. Going off of the idea that "any tests are better than no tests", it aims to get your system under test (and give you some peace-of-mind that things are doing what they should) by painting with as broad a strokes as possible.

It's a *temporary* solution that should, responsibly, be replaced with more thoughtfully designed and employed tests at some time in the future (post-refactor).

If these tests start out as the stop-gap measure that ends up becoming permanent, you *will* feel the pain. The same way that anyone who has a business critical process that depends on one member of the team who decides to leave the company, gets hit by a bus, etc feels the pain when one of these scenarios happens.

These tests provide a great place to start, but eventually your system needs to grow into accomadating a more mature test suite that is equal parts business-behavior-verifying, sustainable and performant. Fixing these tests is concerned "paying down a design debt"

### The Hasty Fighting Position As A Metaphor For Outside-in Testing
The Hasty Fighting Position (aka the Ranger Grave) is a US Army Light Infantry doctrinal approach to allow soldiers to quickly "dig-in" and establish a lightly fortified position to be defended for ~48 hours or less. After that, they need to either bug out or build better fighting positions (pay their design debt).

It has the following characteristics:
* Provides some cover and concealment from the enemy
* Meant to accomadate teams, but can be made solo (usually working in teams of two, one soldier digs while the other pulls security)
* perhaps most importantly, it quick and easy to make and pays dividends immediately. Kneeling better than standing, prone better than kneeling, ranger graves are better than just laying in the dirt.

Outside-in testing is like this. It's a "black-box" approach to testing without much consideration paid to implementation details beyond those germaine to the test framework.

These tests typically end up living in the end-to-end test layer.