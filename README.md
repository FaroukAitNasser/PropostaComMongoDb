# .NET 6 Web API - MongoDB CRUD

This project is a .NET 6 Web API that performs CRUD operations for two entities: `Pessoa` (Person) and `Telefone` (Phone), using MongoDB as the data store.

## Features

- Built with ASP.NET Core 6
- RESTful API endpoints
- MongoDB persistence
- MongoDB connection via Docker container
- Swagger UI for testing

## Running MongoDB with Docker

Use the command below to run a MongoDB container:

```bash
docker run -d -p 27017:27017 --name mongodb mongo
```

> Make sure Docker is installed and running on your system.

## Configuration

MongoDB settings are stored in `appsettings.json`:

```json
"MongoDB": {
  "ConnectionString": "mongodb://localhost:27017",
  "DatabaseName": "MyApiDb"
}
```

## Running the Project

```bash
dotnet run
```

Then open: https://localhost:7091/swagger

## API Endpoints

| Method | Route            | Description       |
| ------ | ---------------- | ----------------- |
| GET    | /api/pessoa      | Get all pessoas   |
| GET    | /api/pessoa/{id} | Get pessoa by ID  |
| POST   | /api/pessoa      | Create new pessoa |
| PUT    | /api/pessoa/{id} | Update pessoa     |
| DELETE | /api/pessoa/{id} | Delete pessoa     |

## Notes

- Data is stored in MongoDB.
- The API expects MongoDB to be running locally at `localhost:27017`.
- Adjust settings in `appsettings.json` if needed.
