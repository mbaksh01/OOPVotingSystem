# OOPVotingSystem

A prototype voting system which can be use to cast votes, create and manage
elections and parties.

## User Requirements

- A user must be able to cast a vote.
- A admin must be able to create and manage elections, parties and candidates.
- The system must be able to interact with other types of voting systems,
e.g. First Past the Post, Single Transferable Vote, etc.
- Auditors must be able to add votes which were not entered through the voting system.
- The system must be able to respect and follow GDPR rules.

## Framework

This project is using Blazor Server to manage a database and provide web based
GUI for users.

### Client Side

A user would connect to a hosted instance of application. This instance would
provide the HTML and CSS across the wire for it to be displayed to an end user.

### Server Side

This system uses EntityFramework as the database management system. The backing
provider for the database is SQLite with the .db found at the root of this project.

## Design Pattern

This project is using the Repository pattern. The repository pattern isolates
the data access layer from the service layer and GUI layer, only exposing the
appropriate methods for services to interact with.

This design pattern also helps de-couple the service layer, data access layer
and GUI layer. By doing so changes on a single layer would have little to no
impact on the methods and classes which use it. It also increases testability
as a small part of the code can easily be isolated and tested.

## Supported features in the current prototype

- Users can login and create an account.
- Users can cast a vote in a election for a part.
- Users can manage and view they accounts.
- Admins can preform CRUD operations on elections and parties.
- Data is persisted using a SQLite database file.
