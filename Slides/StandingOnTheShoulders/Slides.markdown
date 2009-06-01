% Standing on the Shoulders of Giants
% Everyone

We're going to cover a lot of ground in the session, so we're going to
be flying pretty high. We could easily spend a week going over this
stuff in detail, so please consider this session just an
overview. Hopefully this will help you build a mental model of some of
these concepts, which you can build upon later.

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

(code: OCP example)

## Liskov Substitution Principle

"FUNCTIONS THAT USE POINTERS OR REFERENCES TO BASE
CLASSES MUST BE ABLE TO USE OBJECTS OF DERIVED CLASSES
WITHOUT KNOWING IT."

(code: LSP example) 

## Interface Segregation Principle

You shouldn't be forced to implement parts of an interface you don't
use.

I think of this as SRP for interfaces. If you find yourself with
classes that implement interfaces and throw NotImplementedException or
otherwise don't really do any work to implement parts of the
interface, that's where you need to apply ISP.

Often, this means breaking the interface into several interfaces,
grouped together so no one needs to throw NotImplementedException.

(code: ISP example)

## Dependency Inversion Principle

- High level modules should not depend upon low level modules. Both should depend
  upon abstractions.
- Abstractions should not depend upon details. Details should depend upon
  abstractions.

(code: DI example)

# Base Patterns

On the next few slides, we'll talk about some of the base patterns the
others are built on. You've undoubtedly run across these before. I've
added a short, one line description. That's not the whole story -
there is a lot more to these patterns than that, and I'd encourage you
to checkout POEAA and DDD to get a fuller picture - but hopefully it
captures the essence and is easy to remember.

## Domain Model

_The real world's proxy in your system_

## Gateway

_An interface to another system_

## Controller

_An interface from another system_

# Data Access Patterns

Most of the applications we work on have something to do with a
database, so these patterns are very core to our work.

## Row/Table Data Gateway

These are typically the first patterns we learn when using object
oriented languages to access data - even if we don't know it!

How could we be using it without knowing? 

Let's make an example:

(code: row data gateway)

Have you ever written or used a class like that? 

What about Table Data Gateway? 

Let's look at the DataAdapter class in System.Data.

(code: DataAdapter and specialization of)

So DataAdapters are like generic, enemic, parameterized Table Data Gateways.

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

(code: simple Active Record)

Like row data gateway, Active Record suffers from problems when you
want to add data access features. You end up having to add them to
the same classes that implement your business logic, which can be kind
of messy.

Another issue you frequently run into, particularly with Active
Record, but also with the other data access patterns we've talked
about so far is that they are tightly coupled to the database. As you
system evolves, at some point you may find it more convenient to
implement some features in the application in a way that differs from
the way they are structured in the database.

We'll come back to this in a little bit when we talk about Command
Query Separation, but for now, think of the domain model you get using
these patterns as being derivable from the database, or vice versa.

## Repository

Repository comes out of the Domain Driven Design world. I think of
repository as being like Table Data Gateway, but with the intention
being more about fetching root objects ("aggregate roots" in DDD
parlance) and less about dealing directly with a table.

What's an aggregate root? When you're implementing a feature and you
find that you are always working in the context of a particular object
- such as a Case in SUFORS - that's a good indication that the object
is probably the aggregate root. Other objects in the system might not
be useful enough on their own, unless you have the aggregate root in
context.

Repository makes it easy to fetch aggregate roots along with their
whole entourage. You could do this with Table Data Gateway too, and
this is what Data Adapters do to a fault when fetching huge relational
snapshots from the database into datasets, but with Repository, that's
what it's all about.

Ideally the repository is a gateway, in the sense that it acts as a
membrane between our application and the database and keeps it's
dependents persistence ignorant.

(code: case repository in SUFORS)

## Persistence Ignorance

There are a lot of reasons I don't want my whole application to have
to know about how/when/if things are being persisted to a database. To
me, these reasons can be summed up simply: It's none of your
business. As soon as every component is responsible for persistence
issues, non of them will be, and this is a recipe for spaghetti.

As you design the persistence parts of your application, I encourage
you to try and keep persistence at one edge of the system. This pays
off as the system grows.

# Application Logic Patterns

## Domain Model

A domain model makes it easier to model the real world in
software. The classes you see here should be real terms that are used
in the domain. These are the nouns of the business.

## Service Layer

And here are the verbs.

I think the idea that it's a layer is less important than the fact
that verbs are separate, and this stuff isn't buried in controllers or
otherwise coupled into some other component. The main idea is that
dependencies needed to accomplish specific tasks are concentrated
here.

A lot of times, I will start building a UI based on information I've
gathered. I will write just enough logic to make something show up on
the screen, then start working backwards from there.

As long as I have tests in place, and I'm not making a big production
out of it, I might start building the service inside of a controller.

(code: controller with lots of dependencies...then start extract
method -> extract class -> move dependencies)

The drawback here is you spend more time moving stuff around in your
unit tests. This is kind of where the whole spec driven development
thing comes in for me - instead of changing the name or location of
tests, I just need to change their structure and subject when
extracting classes.

## Factory

Factory is about concentrating creation logic. Factories know about
dependencies a component has and know the right way to satisfy them. 

I think of factory as kind of a dead or stepping stone pattern now. I
rarely use it, but it's important and good to know.

## Service Locator

This is like factory for longer lives services. Instead of knowing how
to create components, it just needs to keep track of the ones that are
already created.

This is another pattern I don't use very much anymore, but Factory and
Service Locator are two core concepts that lead to our next pattern.

## Dependency Injection

Remember the DIP discussed earlier? This is a nice pattern for
implementing it. 

Dependency Injection is about expressing what a component needs in
terms of abstractions, not details. If a component needs a particular
service, it depends on the service by contract name (typically an
interface type), not on any specific implementation.

When you use the new operator, you are specifying exactly which
implementation you are dependent on. To keep our design clean, instead
of sprinkling this choice all over, it makes sense to keep that
decision our of the dependent component and move it somewhere else. 

"Injecting" a component's dependencies, maybe via a constructor for
example, is what is meant by dependency injection.

(code: bad service...news up other services)
(refactor: good services...gets those services as dependencies in constructor)

There are a variety of "dependency injection containers" you can use
these days to outsource this concern: Castle Windsor, Structure Map,
Ninject, Unity. You can find links on the links page.

## Presentation Patterns

## Controller

Controllers should be thin endpoints that map some desired behavior to
service entry points - ideally one entry point.

Controllers usually need to have details on what kind of presentation
technology the application is using.

For example, in a web application, a controller probably needs to be
http addressable somehow.

There is a convention, I believe started by Rails, where controllers
are responsible for some area of the application and actions are the
specific response handlers. So ReportIntake/Abduction.rails might
resolve to calling the Abduction method on the ReportIntake controller
class. This is also the convention for Monorail and ASP.NET MVC.

Frameworks like MR and AMVC can help remove a lot of the http-ness
from controller actions. Usually you can just declare parameters of
primitive types and the infrastructure will take care of converting
URL or POST content into those parameters. For richer request
responses they can create objects from form fields or deserialize JSON
into .NET objects. Same goes for the response.

So if controllers don't need to know much about http, and all their
logic has been extracted to services, what's the point of having a
controller?

## Supervising Controller vs. Passive View (Model View Presenter)

Our controller definition above doesn't have the controller doing much
with the view. It's receiving commands or returning objects to the
view, but it's not manipulating UI components. In fact our controller
is more like a service facade, like something out of WCF.

Personally, I am fine with that. In the web application space where I
work, we are moving more and more logic into the presentation layer
anyway (javascript) and starting to refine some of these patterns
there, so we really only need a service facade anyway.

For rich and middle class (Silverlight) applications there are more
choices.

Supervising Controller is a pattern where we take as much of the view
logic as possible out of the view and put it into a
controller. The controller is tightly coupled to the UI presentation,
but easier to test because it's a separate object.

Passive View is similar, but all UI commands are implemented by the
Controller/Presenter class. 

These two patterns are really about the controller helping out with
more of the view's work and giving the view less of a dependency on
the model.

## View

What is this View thing we keep talking about?

If we're talking about HTML, it's the HTML, or perhaps a template for
generating HTML, like an ASPX file.

In Windows Forms, it's the form. In WPF, the XAML.

It's single responsibility is to contain all the information about
what UI elements to display on the screen...and maybe to bind objects
to them.

## Presentation Model

Instead of talking directly to UI components we could model them and
talk to the model.

This is where you get things like having a view with properties where
the getters and setters are implemented by getting and setting values
in some UI widget.

With this abstraction in place, 

## MVVM

## MVC

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
