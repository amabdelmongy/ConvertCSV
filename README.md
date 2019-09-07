# ConvertCSV
REST- Interface using C# and .NET read from CSV

The goal is to implement a REST- Interface using C# and .NET. The following requirements have to be met:
 It should be possible to manage people and their favorite colors over the interface
 The data should be read from a CSV file without the need to customize the CSV itself
 All people with specific favorite color can be determined over the interface 

1. Read the CSV file and cache in a Json fitting model class (needs to be implemented). Ideally this
should happen in a class, that abstracts the access to the file, thus this could be replaced through
a simple database.
2. Implement the given REST- interface. The interface accesses the persistence class via
Dependency Injection.
3. Write fitting unit tests for the interface (e.g. GetUsersWithColorTest(), GetAllUsersTest())
4. Next work 
 Implementation as a MSBuild project for continuous integration on TFS
 Implement an additional method POST /persons which adds a new record to the CSV file
 Entity Framework- connection to a SQL database to persist the data 