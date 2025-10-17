📚 Book Management Web API
🚀 Tech Stack
* .NET 9
* ASP.NET Core Web API
* Entity Framework Core
* MSSQL Server
* Scalar UI for documentation/testing interface
* Repository
* N-Layer Architecture

🎯 Objective
Provide a fully functional API with the following capabilities:
* Get all books
* Get book by ID
* Add new book
* Update existing book
* Delete book
* Categorize books using Enum (Horror, Sci-Fi, Romance, Other)

🔌 API Endpoints
| Method | Endpoint                | Description          |
| ------ | ----------------------- | -------------------- |
| GET    | `/api/GetAllBooks`      | Get all books        |
| GET    | `/api/GetBookById/{id}` | Get book by ID       |
| POST   | `/api/CreateBook`       | Add a new book       |
| PUT    | `/api/UpdateBook/{id}`  | Update existing book |
| DELETE | `/api/DeleteBook/{id}`  | Delete book by ID    |


🛠️ Clone and Run
# Clone the repository
git clone https://github.com/yourusername/BookManagementAPI.git
cd BookManagementAPI

# Restore dependencies
dotnet restore

# Apply EF Core migrations
dotnet ef migrations add BookManagementMigration
dotnet ef database update

# Run the application
dotnet run --project BookManagementAPI

🔍 Testing API
# Scalar UI : https://localhost:{PORT}/scalar