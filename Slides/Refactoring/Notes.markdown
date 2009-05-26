# What is refactoring not?

Refactoring is a loaded term in software engineering. 

For the kind of refactoring we're talking about, it's easier to define
in terms of what it is not.

A lot of times you'll hear people use the word refactoring as a
blanket for hiding work that has no buisness value. Refactoring sounds
kind of valuable technically to a non-technical person and they may be
afraid to question it's importance. 

It might even sound like failure to do the refactoring might result in
negative impact to the quality of the end product.

There is an implicit understanding between technical and non-technical
people on software projects that refactoring adds some kind of
value. They're just not sure what it is or what it's business value
is.

This is not the kind of refactoring we're talking about.

# Let's call this "Big 'R' Refactoring"

We're talking about something different. To distinguish it, when there
is a question as to which kind of refactoring we're talking about,
let's call the good kind, "Big 'R' Refactoring", with the implication
being that it's better somehow.

# What is refactoring not?

"We're going to be refactoring for the next few weeks..."

Big-R Refactoring is about adding value that cannot be measured, just
like a non-technical person's perception of little R refactoring.

The difference is that in Big-R, we're aware of the fact that we're
not adding value (that can be measured,) and as a result, we don't
want to spend more than the minimum amount of time doing this.

Big-R should be something you incorporate as part of a tight cycle of
almost continual delivery of business value.

It the "cleaning up the shop floor" part of running a garage. A garage
would quickly go out of business if they spent one week in four doing
nothing but cleaning up. In fact, if they had made a mess so big that
it took a week to cleanup, it's hard to imagine how they were getting
any work done in the final week of mess making.

Big-R refactoring is about cleaning up as you go and not waiting till
the mess completely obscures the work.

# What is refactoring not?

"We don't need to fix that bug. It'll get fixed by our refactoring."

Big-R doesn't start when the system is in a broken state. Fixing bugs
is equivalent two adding features (or maybe, "re-enabling features" is
more appropriate.)

Cleaning up the mess on the shop floor is not part of changing the
customer's brake pads. Big-R recognizes this, keeping the two as
seperate activities, while still stressing the importance of keeping
the shop floor clean.

# What is refactoring?

Refactoring is improving the design of working code, without changing
it's features.

Why is important that the code be working before we refactor? 

Only by being working, by being valuable, do we know that the code is
even worth refactoring. If nobody comes to our garage to change brake
pads, there shouldn't be any mess - no empty boxes of brake pads or
grease on the floor. Nothing to clean.

Refactoring is kind of like this. If some software gets built that is
not valuable, throw it away. Maintenance of software is expensive, so
why incur these costs for something that has no value.

# What is "technical debt?"

Technical debt is a term used to describe the mess on the shop floor.

It's OK to incur some technical debt to get value delivered. There is
nothing wrong with that. Technical debt is the leverage we use to make
sure features are delivered as soon as possible. Without incurring any
technical debt it would always take too long to deliver features.

The trick is to be disciplined enough to pay down technical debt on a
regular basis. To make it part of your routine.

# The 3-state machine

The routine that refactoring is a part of is a state machine.

It has only three states:

- You've specified an unimplemented feature. Tests fail. You're red.

- You've implemented the feature in the quickest way possible,
  possibly incurring technical debt. You're green.

- Your cleaning up the design, staying green the whole time. Making an
  incremental payment to the technical debt you've
  incurred. With practice, you can reach net zero, where the debt you
  incur is paid off at the end of the cycle.

# No new features

As soon as we start adding new features, we're back to red. At that
point, we're done refactoring. If we've got some debt, it's getting
rolled over into the next refactoring.

Feel that? That's the pressure of unpaid technical debt.

This cycle is repeated in a tight loop, maybe 10 - 30 minutes. We're
never refactoring for long periods of time with Big-R.

What about legacy applications that have lots of technical debt? How
do we pay that off?

Answer: One payment at a time. 

If we put off adding features to pay down legacy technical debt, we're
only going to increase the pressure to deliver value. Instead, we
should strive to continuously deliver value and make paying down
technical debt a part of that process, in small, managable steps.

# Extract data access stuff from template to Page_Load, test

Identify the technical debt here: There is code in the ASPX template
that the compiler can't see at compile time and we can't use from
anywhere else. The page is doing more than one thing - it's showing
the data and it's in charge of getting the data.

A brief introduction to SRP.

Move this code to Page_Load, then, run Jeff's tests.

# Extract method, test

Page_Load? What does that do?

Let's extract the stuff we just added into a method on the code
behind.

Re-test.

# Extract into component, test

Code behind is still not SR. What's the name of this extra thing we've
added? Let's make a class called that, which just does that.

Re-run tests.

# Isolate database from business logic, test

What about the stored procedure that we're using? Could we get that
logic into code, with tests? Should we? Discuss.

If we were going to do it, how?

(Should we just use NHibernate or something, just as an example?)

# We're _just_ improving the design

We haven't added any features. The application still does exactly the
same things as it did before. Good thing we didn't spend too much time
on that or we'd be incurring a different kind of debt.

We also kept the light green most of the time. That's expected since
we didn't add any new features.

# Service

The type of component we extracted into is often referred to as a
"service." It's an action component - it does something - not an
"entity", or a noun.

Often times, complex methods or methods that don't sound like they are
part of the process named by their class name are good places to look
for technical debt.

One of the problems we still have with the design as it stands is that
the page is responsible for creating the component and the lifetime of
the component. What if the component had other dependencies - like a
database connection manager class that we might extract later, or some
service that does some kind of special calculation? Now every place
that uses this component would need to know about these services, have
or make them available, and deal with _their_ dependencies. Yuck!

# Service Locator

Service locator is one solution to this problem. Instead of "new
MyComponent(dependency1, dependency2, ...)" this would be the service
locator's problem.

# HttpContext in the helpers

Another great candidate service is the HttpContext stuff in the
helpers. Anything called "Helpers" is a family of services waiting to
be born.


