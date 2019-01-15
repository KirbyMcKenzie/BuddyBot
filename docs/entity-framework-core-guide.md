# Entity Framework Guidance

## To add a data model
 1. Create Data Model in Repository project
 1. Register data model with BuddyBotDbContext
    - Add DbSet Property
    - Define modelbuilder behaviour
 1. Run Add Migration -see below
 1. Run Update Migration

## Entity Framework commands
>  run from within .Repository project 

### To add a migration
`
dotnet ef --startup-project ..\\BuddyBot.Repository.Startup\\ migrations add "<Migration Name>"
`

### To update the database
`
dotnet ef --startup-project ..\\BuddyBot.Repository.Startup\\ database update
`

### To remove a migration

First you must update the database to the migration you'd like to roll back to:

`
 dotnet ef --startup-project ..\\BuddyBot.Repository.Startup\\ database update <previous-migration>
`

Then remove the most recent migration:

`
dotnet ef --startup-project ..\\BuddyBot.Repository.Startup\\ migrations remove

### Generate sql script

`
dotnet ef --startup-project ..\\BuddyBot.Repository.Startup\\ migrations script -o <filename>
`