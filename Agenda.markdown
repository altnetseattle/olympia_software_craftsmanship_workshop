
# Questions

# Agenda

## Introduction (15 minute) (10-10:15am) [Trevor, Chris]
* What are we doing today...
* what app is

## Classic ASP.NET Development (45 minutes) (-11pm) [Bobby]
* Show the existing
* Add a feature find orphan reports and associate citizens

## Getting the system under test (45 minutes) (-11:45) [Jeff]
* Outside in tests
* Bug example: Citizen -> Add new citizen. Cancel. Cancel Again, but navigation broken. Or a state dependent bug.

## Lunch (11:45)

## what I really wanted was... (45 minutes) (-12:30) [Trevor]
* Stories
* Backlog
* Do you really think you can get all the requirements up front?
  + -> solution: design must be supple and easy to change.
  + regardless of intention, you're going to have to change design
* new feature request (that's hard to do without refactoring, something that breaks the schema, we'd have to search SQL strings all over)

## Refactoring (12:30pm - 1:30pm) [Justin?, Chris]
* Introduction to refactoring
  + The 3-state machine
  + No new features
* Extract data access stuff from template to Page_Load, test
* Extract method, test
* Extract into component, test
* Isolate database from business logic, test

## TDD (1:30pm - 2:00pm) [Robin]
* Seams, Isolating the thing to test
* The importance of TDD in refactoring

## Add features (2:00 - 2:30pm) [Chris]
* Using TDD
* Assigning concern code to a citizen 

## Standing on the shoulders of giants  (2:30 - 3:00pm) [Jeff]
* Common ways of solving these problems...
* Strategy - the switch statement
  + We don't want to touch code all over the place...
  + This is called the "Strategy Pattern"
* All these things are patterns

## Refactor again (3:00pm - 3:30) [Chris/Justin]
* We're _just_ improving the design
* Service
* Service Locator
  + for components above (new DAComponent -> serviceLocator.Get<IComponent>()
* This enables us to add features like... (Bobby's example of getting e-mail address to auto-associate report with citizen) 
* HttpContext in the helpers
  + Navigation service

## Retrospective (3:30 - 3:45) [Everyone]
* We're inverting control
* We're Evolutionaryily designing
* Look, the tests still work, time for beer

## Extras (3:45 - 4pm) [Everyone]
* Castle, Ninject, etc.
* where are the links

## TODO
* [ ] Projector - Chris

## Parking Lot


