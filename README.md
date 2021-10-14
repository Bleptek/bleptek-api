# Aarhus Vandsportscenter - REST API

This serves as the backend for the bleptek.dk website.

## About this project

Hosted at:

- http://bleptek.dk/api/v1 (prod)
- http://dev.bleptek.dk/api/v1 (dev)

**Highlights:**

- .Net 5
- The API is documented using Swagger UI at /swagger.

### Prerequisites

- .Net SDK 5.0.1

## Getting Started

### Environment variables

Read through the appsettings.json configuration file for any values missing.
This is essential before the project can run without error.
Using VS Code, a launch.json file can have a configuration containing an env object as such: 

```
"env": {
    "ASPNETCORE_ENVIRONMENT": "Development",
    "someprop:nestedprop": ""
}
```

## Run the app

Using Dotnet

```sh
dotnet run --project ./src/Bleptek.Api/
```

## Deployment & hosting

The application is currently hosted at Simply.com.
We use github actions as CI/CD tool. Upon pushing to the Dev branch, any changes will be deployed to our Test server.
In the csproj file the following applies to the Debug configuration: 

```xml
<PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
    <AspNetCoreModuleName>AspNetCoreModule</AspNetCoreModuleName>
    <AspNetCoreHostingModel>OutOfProcess</AspNetCoreHostingModel>
</PropertyGroup>
```

This enables running multiples applications in the IIS app-pool on the server.
The main application runs In-process and all others run Out-of-process.
