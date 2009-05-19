% Refactoring
% Justin and Chris

# What is refactoring not?
Refactoring is a loaded term in software engineering. 

# What is refactoring not?
For the kind of refactoring we're talking about, 
it's easier to define in terms of what it is not.

![](Refactoring_and_not_Refactoring_Venn_Diagram.png)

# Let's call this "Big 'R' Refactoring"
![](Big_R.png)

# What is refactoring not?
"We're going to be refactoring for the next few weeks..."

> * Refactoring _adds_value_that_cannot_be_measured_
> * Unless you don't care about value, you can't be refactoring for long periods of time

# What is refactoring not?
"We don't need to fix that bug. It'll get fixed by our refactoring."

> * Refactoring doesn't start when the system is in a broken state

# What is refactoring?

# What is "technical debt?"

# The 3-state machine
![Red-Green-Refactor Graphic]()

# The 3-state machine
Red-Green-Refactor:
* Red -> Adding new features <- breaking tests
* Green -> Features implemented, barely
* Refactor -> Technical debt paid off

# No new features
Should not "go red" while refactoring

# No new feature
![Stepping stones picture]()

# Extract data access stuff from template to Page_Load, test
(code)

# Extract method, test
(code)

# Extract into component, test
(code)

# Isolate database from business logic, test
(code)

# We're _just_ improving the design
* We haven't added any features
* At any (ok..._almost_ any) time during above work we were green

# Service

# Service Locator
for components above (new DAComponent -> serviceLocator.Get<IComponent>()

# This enables us to add features like... (Bobby's example of getting e-mail address to auto-associate report with citizen) 

# HttpContext in the helpers
Navigation service
