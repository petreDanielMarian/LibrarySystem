# LibrarySystem

I used Rider to develop this project (.NET Framework 4.8)

### Pre-req:
- xunit and FluentAssertions nuget packages must be installed for AutomaticTestsProject
- MSBuild 16.0

### Run the app
- Select project Library to build and run
- When the console pops up, use arrow keys to move around the menu options
- You'll have to choose one User: Admin or User
  - Each user has its own set of actions. Seemed more normal to me that only an admin should add books to the library and only a regular user should be able to borrow and return books.
- After that, you can either Add books (as Admin) or borrow and return books (as User).
- Both user types can check what books are availalble and how many copies of them are still in the library.
- To switch between the user types, use "Switch user" menu option
- Go nuts!
