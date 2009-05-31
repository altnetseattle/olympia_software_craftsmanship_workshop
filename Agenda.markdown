Agenda
======

# Introduction (15 minute) (10-10:15am) [Trevor, Chris]
* What are we doing today...
* what app is

# Classic ASP.NET Development (45 minutes) (-11pm) [Bobby]

We're going to do a first cut just building a plain old ASP.NET web
forms application. We'll think about the first scenario in the
stories, not considering the second story.

Next we'll look at adding the second scenario and show how it's
difficult with the poor design we've slapped together.

We'll consider things like keeping the SQL into a stored procedure and
other steps we might take to get this under control, and discuss the
pros and cons of each approach.

# Getting the system under test (45 minutes) (-11:45am) [Jeff]

Since we have no tests and an untestable design, we're going to start
with [outside in tests][1] to get something around the system.

We're going to look at automated web testing frameworks like Watin and
Selenium and how we can use them to build up integration and
acceptance tests.

# Lunch (11:45am-12:30pm)

# What I really wanted was... (45 minutes) (-1:15pm) [Trevor, Everyone]

Do we really think we can get all the requirements up front?

The one constant in software development is change. How well your
design can be changed will make or break it.

In the process of interviewing our customer and talking about what he
really wanted, we'll discover just enough information to complete the
next part of our application.

We'll talk about different ways to collaborate with product owners and
customers to get the information we need to solve problems, how to
manage a backlog of this information, and ways to process that
information more efficiently.

# Refactoring (45 minutes) (1:15-2pm) [Justin, Chris]

With the new information we've gotten from the customer, we'll start
changing our design to get into a position to process that
information.

We'll focus on the basic rules of refactoring and how we can use these
techniques to make our design more supple.

# Break (2-2:15pm)

# TDD (2:15-3pm) [Robin]

Now that we're ready, we'll use TDD techniques to drive the design of
a new feature we want to add to the application.

# Standing on the shoulders of giants  (2:30-3:15pm) [Everyone]

We'll talk about patterns we could use going forward to improve our
application, and how others have solved these problems in the past.

# Extras (3:15 - 3:30pm) [Everyone]
* Castle, Ninject, etc.
* where are the links

## Retrospective (3:30 - 4pm:) [Everyone]
* We're inverting control
* We're Evolutionaryily designing
* Look, the tests still work, time for beer

[1]: http://xunitpatterns.com/Philosophy%20Of%20Test%20Automation.html
     "Philosophy of Test Automation"

