# Dotnet core Cosmos DB (in Mongo Mode) Demo

## required versions and packages

1. Dot Net Core 2.x SDK
2. Dot Net Standard 2.x
3. Others... See `cosmosdotnetcore.csproj` file for details

Note: `dotnet restore` should add whatever is needed, but some people report that they had to install the `dotnet core 2 SDK`(https://www.microsoft.com/net/download/core) first

## How to use

1. Create a Azure Cosmos DB instance in Mongo mode
2. Create a Database
3. Create a Collection
4. Create some data (see below)
5. Put data into the collection (see below)
6. Get the connection string, database name, and collection info
7. Create a `settings.json` file (see below) and put the data above into it
8. Run the demo

```bash
$ dotnet restore
$ dotnet run
```

## How to create the sample data

You can create data using the little utility at: https://github.com/BlitzkriegSoftware/NoSqlDataMaker 

It makes people JSON that can be used for this demo

## How to import data

Use the instructions in the data maker to use `mongoimport` to populate the collection (do not use the Cosmos DB import tool!)

## Settings.json file format

This is the file format for `settings.json` file

```json
{
	"ConnectionString": "",
	"Database": "",
	"Collection": ""
}
```


