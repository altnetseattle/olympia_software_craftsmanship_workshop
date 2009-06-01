% Standing on the Shoulders of Giants
% Everyone

# Some Principles

## SOLID

SOLID is an abbreviation for a set of five design principles first
coined by Robert Martin in the late nineties. 

There is a PDF on the DVD which is an ebook about the solid
principles, written by the Los Techies bloggers. It's a really good
resource for learning this stuff.

### Single Responsibility Principle

"A class should have only one reason to change."

I think we can all agree that the name of a class should decribe what
it does not how it does it. If something about _doing that one thing_
changes, then the class needs to change. If something about doing some
other thing changes, that class should not need to change.

A lot of times, I find I start out with a nice simple class that has
one responsibility and makes me feel real good. Then I go to add some
feature and suddenly, the class is doing more than one thing, without
me realizing it. It's very hard to notice this at first, but there are
some warning signs:

- Classes the have dependencies on things they don't seem to need if
  you haven't looked in their guts.
- Methods doing things that don't seem to have anything to do with the
  name of the class or method. This one's a little more subtle.
- Methods with if statements leading to different ways to implement
  the same thing. (special cases)
- An abundance of overloads.

Some of these smells can also be indicative of other kinds of
problems, but for most of this talk, we're going to focus on SRP.

## Open Closed Principle

"Classes should be open for extension but closed for modification."

## Liskov Substitution Principle

"FUNCTIONS THAT USE POINTERS OR REFERENCES TO BASE
CLASSES MUST BE ABLE TO USE OBJECTS OF DERIVED CLASSES
WITHOUT KNOWING IT." 

## Interface Segregation Principle

You shouldn't be forced to implement parts of an interface you don't
use.

I think of this as SRP for interfaces. If you find yourself with
classes that implement interfaces and throw NotImplementedException or
otherwise don't really do any work to implement parts of the
interface, that's where you need to apply ISP.

Often, this means breaking the interface into several interfaces,
grouped together so no one needs to throw NotImplementedException.

## Dependency Inversion Principle

- High level modules should not depend upon low level modules. Both should depend
  upon abstractions.
- Abstractions should not depend upon details. Details should depend upon
  abstractions.

# Base Patterns

## Domain Model

* The real world's proxy in your system

## Gateway

* An interface to another system

## Controller

* An interface from another system

# Data Access Patterns

Most of the applications we work on have something to do with a
database, so these patterns are very core to our work.

## Row/Table Data Gateway

These are typically the first patterns we learn when using object
oriented languages to access data - even if we don't know it!

How could we be using it without knowing? 

Let's make an example:

(code)

Let's look at the DataAdapter class in System.Data.

(code)

So DataAdapters are like generic, parameterized Table Data Gateways.

The nice thing about table data gateway, an advantage over row data
gateway, is that you've isolated the data access logic away from the
business logic. This comes in handy when you start to add data access
features, like scoped transactions or connection/session management,
which we'll get to in a little bit.

## Active Record

Active Record, not to be confused with any particular library or
product that calls itself Active Record, goes the complete other
direction. Entity classes in Active Record are responsible for their
own persistence. 

(code)

Like row data gateway, Active Record suffers from problems when you
want to add data access features. You end up having to add them to
the same classes that implement your business logic, which can be kind
of messy.

## Repository

 

## Command-Query Separation

## Persistence Ignorance

# Application Logic Patterns

## Domain Model

## Service Layer

## Factory

## Service Locator

## Depedancy Injection

## Presentation Patterns

## Controller

## Presenter

## View

## ViewModel

## MVVM

## MVC

## MVP

## Are View Models Just Messages?

# Some Lessons From Functional Programming

## Currying: It Lets You Route Messages

## Function Composition: It's kinda like service composition

## Functions: SRP and Side-Effect Free

## Currying: It's kind like dependency inversion too!

# Towards a Message Driven Architecture

## Some Principles

## Controllers Aren't Composable, Services Are

## Views Aren't Composable, View Models Are

## Boundaries should be explicit...

## But boundaries should do one thing well: Be boundaries

# Example: Controller as a JSON Service 
