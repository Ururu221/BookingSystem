# BookingSystem Web API

**BookingSystem** is a clean and well-structured Web API project built using **ASP.NET Core 8**, following **SOLID principles** and leveraging **Dependency Injection (DI)** throughout the codebase. It separates responsibilities across layers (Controllers, Services, Repositories) and includes **unit tests** using **xUnit** and **Moq** to ensure code reliability.

This project demonstrates good architectural practices, scalability, and readability — a great example of how to build a simple backend system for room booking while keeping the code clean and maintainable.

---

## 🔧 Technologies Used

- ASP.NET Core 8
- Entity Framework Core 9
- PostgreSQL
- xUnit (Unit Testing)
- Moq (Mocking Dependencies)
- Swagger / OpenAPI

---

## ⚖️ Project Structure

```
BookingSystem/
├── BookingSystem-web-api/         # Main Web API project
│   ├── Controllers/               # API endpoints
│   ├── Services/                  # Business logic
│   ├── Repositories/             # Data access logic
│   ├── Models/                   # DTOs and EF entities
│   └── appsettings.json          # Config file with connection string
├── BookingSystem.Tests/          # Unit test project (xUnit + Moq)
├── BookingSystem-web-api.sln     # Solution file
```

---

## ⚙️ How to Run Locally

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [PostgreSQL 13+](https://www.postgresql.org/download/)

### Steps

1. **Clone the repository**
```bash
git clone https://github.com/Ururu221/BookingSystem.git
cd BookingSystem
```

2. **Configure your database**  
Update the connection string in `BookingSystem-web-api/appsettings.Development.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=room_booking_system;Username=postgres;Password=your_password"
}
```

3. **Apply EF Core migrations** (if needed):
```bash
cd BookingSystem-web-api
dotnet ef database update
```

4. **Run the API**
```bash
dotnet run --project BookingSystem-web-api
```

Visit: [http://localhost:5000/swagger](http://localhost:5000/swagger) or [http://localhost:8080/swagger](http://localhost:8080/swagger)

---

## 📃 Available API Endpoints

### 🚪 Rooms
- `GET /api/rooms` — Get all rooms
- `POST /api/rooms` — Create a new room

### ✅ Bookings
- `GET /api/bookings` — Get all bookings
- `POST /api/bookings` — Create a booking

### ❓ Test Endpoint
- `GET /` — Returns "Hello World!" (basic health check)

---

## 🔮 Running Tests

```bash
dotnet test
```
Unit tests are located in the `BookingSystem.Tests` project.

---

## 👥 Author

Made with care by [@Ururu221](https://github.com/Ururu221)

Feel free to explore, fork, and improve the project.

