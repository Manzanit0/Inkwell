# Inkwell

This project is a personal implementation of a blog.

## How can I get it up and running?

The pre-requisites are having [.NET Core 2.1](https://www.microsoft.com/net/download) & [MariaDB](https://mariadb.com/kb/en/library/installing-mariadb-on-macos-using-homebrew/).

If you already have MariaDB installed, run the service:

```
mysql.server start
```

With the project cloned and the DB service in place, execute migrations. 
This will create the Database with the correct schema for the project.

```
dotnet ef migrations add InitialCreate
dotnet ef database update
```

Then simply execute `dotnet run`. The web app should be running on `https://localhost:5001`.