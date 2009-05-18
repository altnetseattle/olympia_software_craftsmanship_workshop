# Agenda

## Introduction (15 minute) (10-10:15am) [Trevor, Chris]
* What are we doing today...
* what app is

## Classic ASP.NET Development (45 minutes) (-11pm) [Bobby]
* Show the existing
* Add a feature find orphan reports and associate citizens

## Getting the system under test (45 minutes) (-11:45am) [Jeff]
* Outside in tests
* Bug example: Citizen -> Add new citizen. Cancel. Cancel Again, but navigation broken. Or a state dependent bug.

## Lunch (11:45am-12:30pm)

## What I really wanted was... (45 minutes) (-1:15pm) [Trevor]
* Stories
* Backlog
* Do you really think you can get all the requirements up front?
  + -> solution: design must be supple and easy to change.
  + regardless of intention, you're going to have to change design
* new feature request (that's hard to do without refactoring, something that breaks the schema, we'd have to search SQL strings all over)

## Refactoring (45 minutes) (1:15-2pm) [Justin, Chris]
* Introduction to refactoring
  + The 3-state machine
  + No new features
* Extract data access stuff from template to Page_Load, test
* Extract method, test
* Extract into component, test
* Isolate database from business logic, test
* We're _just_ improving the design
* Service
* Service Locator
  + for components above (new DAComponent -> serviceLocator.Get<IComponent>()
* This enables us to add features like... (Bobby's example of getting e-mail address to auto-associate report with citizen) 
* HttpContext in the helpers
  + Navigation service

## Break (2-2:15pm)

## TDD (2:15-3pm) [Robin]
* Seams, Isolating the thing to test
* The importance of TDD in refactoring

## Standing on the shoulders of giants  (2:30-3:15pm) [Jeff]
* Common ways of solving these problems...
* Strategy - the switch statement
  + We don't want to touch code all over the place...
  + This is called the "Strategy Pattern"
* All these things are patterns

## Extras (3:15 - 3:30pm) [Everyone]
* Castle, Ninject, etc.
* where are the links

## Retrospective (3:30 - 4pm:) [Everyone]
* We're inverting control
* We're Evolutionaryily designing
* Look, the tests still work, time for beer


