SUFORS User Stories and Notes
=============================

# Our Customer

## [Able Probe, Inc.][1]

In generic terms, a company that provides incident report recording
and analysis services, on a contractual basis, to a state
government. Incidents are reported by citizens of the state. In
specific terms, a private company contracted by the State governments
to track citizen reports of UFO incidents, and report on trends and
the credibly worrisome. (In this fictional world, UFO sightings and
contacts with ET’s are as common and nearly as mundane a nuisance as
neighbors with barking dogs or sofas in front yards, etc).

## Company Culture

Company culture is inconsistent and evolving: Mixture of ex-military
people in more senior positions, who are gradually being back-filled
by Web-centric types. Majority of staff are data-entry people or
so-called knowledge workers. They mostly enter data and run queries
and reports. Some in-house techies, but no one capable of building a
new solution.

## Tech Culture 

Oldest employees are accustomed to “green-screen”
applications running on their old IBM AS/400 mini.  Newer employees
and management are Web-savvy, and are demanding a fundamental
technology change, partly for personal reasons, but also to respond
better to the States’ new functional requirements.

# Our Customer’s Customer

Pacifica State Department of Extra-Terrestrial Tracking & Response or
“DETTR”

# Our Mission

Help Able Probe respond to new demands from its largest customer,
DETTR.

DETTR has been publicly promoting the use of text messaging and email
as a way for citizens to report UFO sightings (or more direct, usually
unpleasant contacts). DETTR is trying to minimize pressure on their
1-800 phone service. They want Able Probe to provide much more
efficient incident recording and reporting services via real-time
handling of incoming text messages and email.

Able Probe is in trouble, because they currently use their old
application, the State UFO Reporting System (SUFORS). The people who
wrote SUFORS are long gone, and fixing it wouldn’t really deal with
the fundamental needs of DETTR anyway. They know they have to contract
us to design and build new a Web-centric app.

# Requirements

## Customer Interview

With permission of Able Probe's CEO, Seth Drawlings, we had our
product manager interview several of Able Probe's account managers who
know the existing SUFORS processes and work-flows best. It was clear
that they want us to primarily address improvements to the way Able
Probe staff use SUFORS to handle citizen messages coming in by email
and IM. Currently staff process text files manually entered by
contract staff who transcribe voice mail messages left on the State's
UFO reporting line. The State is asking Able Probe to improve the
software and processes so that Able Probe staff can rapidly process
text from incoming emails and IM messages.

## Entity Model from interviews

### Citizens send Messages
   - IR's review Messages
   - IR's create Incident Records

### Citizen
  - State of Residence
  - State ID Number
  - First Name
  - Middle Initial (optional)
  - Last Name
  - Primary Phone Number
  - Primary Email Address
  - Tracking Flag (defaults to null) List: “loon”, “paranoid”, “anti-gov’t paranoid loon”, "credible source", etc.
	
### Message
  - ID
  - Date-Time Stamp (UTC)
  - Header
  - Content
  - From
  - Originating IPA
   
### User
  - SUFORS ID
  - Primary Role (e.g. "Incident Recorder")
  - First Name
  - Middle Initial (optional)
  - Last Name
  - User Name
  - Password (Encrypted)

### Incident Record
  - ID
  - Date-Time Stamp (UTC)	
  - Message ID
  - Recorder ID
  - Recorder Comments
  - Follow-up Flag (defaults to null) List: “ignore”, “curious”,
    "worrisome", “urgent”, "crisis"

## User Profiles

Incident Recorder (IR): Basic operator of the system, focused on
reviewing citizen messages delivered by a variety of methods
(primarily text messages and emails, but also text records of phone
calls recorded by other staff), and recording them in SUFORS as
"incident records".

## User Stories and Acceptance Criteria

* As an IR, I want to be able to easily view my backlog of incoming, 
  yet unrecorded citizen messages so I know exactly what needs to be 
  worked on.
  - When there are incoming messages, I can see them in my message backlog.
  - When there are messages that have already been recorded, I can no
    longer see them in my message backlog.

* As an IR, I want to be able to link an incoming message (regardless
  of how it was submitted) to a citizen, if that citizen has
  previously sent a message, so I can avoid redundant data entry.
  - When I am working on an incoming message, I can select an existing citizen

* As an IR, I want to be able to auto-populate as much of the incident
  record form as possible, directly from a citizen message, so I can
  minimize my data entry.

* As an IR, I want to be able to view a citizen's historical incident
  records by selecting a citizen anywhere a citizen appears within the 
  application, so I can understand any trends, their reporting
  frequency, date of last report, etc.

* As an IR, I want to be able to flag a citizen for tracking, the flag 
  indicating the concern: "loon", "paranoid", "anti-gov't paranoid loon", etc.

* As a Incident Manager, I want to be notified of new incidents that are 
marked as "crisis" or "urgent", so I can dispatch the appropriate authorities.

[1]: http://ableprobe.com
     "AbleProbe.com"
