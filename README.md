# Chair Seating Application
![Uploading Screenshot (224).png…]()
![Uploading Screenshot (225).png…]()
![Uploading Screenshot (226).png…]()
![Uploading Screenshot (227).png…]()
![Uploading Screenshot (228).png…]()
![Uploading Screenshot (229).png…]()
![Uploading Screenshot (230).png…]()
![Uploading Screenshot (231).png…]()

A full-stack **Chair Seating Management System** built with  
**ASP.NET Core Web API (.NET 8)** and **Blazor Web App (Server, Interactive)**.

The application supports **JWT-based authentication**, **role-based authorization**,  
and allows **Admins** and **Users** to manage and occupy chairs.

---

## 🚀 Features

### 🔐 Authentication & Authorization
- JWT token–based authentication
- Roles: **Admin** and **User**
- Secure APIs with `[Authorize]`
- Role-based UI rendering in Blazor

### 👤 Admin Features
- Create, edit, delete users
- Assign roles (Admin/User)
- Add, update, delete chairs
- View chair occupancy

### 🧑 User Features
- Login / Signup
- View available chairs
- Occupy a chair
- Release own occupied chair
- Cannot release or occupy others’ chairs

### 🪑 Chair Management
- Track chair occupancy
- Prevent double booking
- Show occupied user name

---

## 🛠 Tech Stack

### Backend
- ASP.NET Core Web API (.NET 8)
- Entity Framework Core
- SQL Server
- JWT Authentication
- Swagger (OpenAPI)

### Frontend
- Blazor Web App (.NET 8)
- Interactive Server Rendering
- AuthenticationStateProvider
- JS Interop (localStorage)
- Role-based UI

---

## 📂 Project Structure

```text
ChairSetting
│
├── ChairSetting.API
│   ├── Controllers
│   ├── Data
│   │   ├── Model
│   │   ├── DTO
│   │   ├── Interface
│   │   └── Service
│   ├── AppDbContext.cs
│   └── Program.cs
│
├── ChairSetting.UI
│   ├── Components
│   │   ├── Layout
│   │   └── Pages
│   ├── Helpers
│   │   ├── JwtAuthStateProvider.cs
│   │   └── ApiHttpClient.cs
│   ├── Services
│   ├── Models
│   ├── App.razor
│   └── Program.cs


🔑 Authentication Flow

User logs in

API returns JWT token

Token stored in localStorage

JwtAuthStateProvider reads token

Blazor UI updates auth state

Role-based routes & menus enabled
🧾 Setup Instructions
1️⃣ Backend
cd ChairSetting.API
dotnet restore
dotnet ef database update
dotnet run

2️⃣ Frontend
cd ChairSetting.UI
dotnet restore
dotnet run


API runs on: https://localhost:7233

UI runs on: https://localhost:7201

🔐 Default Admin

Create admin using:

POST /api/Auth/create-admin


Default credentials:

Username: admin
Password: Admin@123

📸 Screens

Login / Signup

Admin Dashboard

Chair Management

User Chair Occupancy

📌 Future Enhancements

Refresh token support

Password reset

Pagination & search

UI theming

Deployment (Azure / Docker)

👨‍💻 Author

Chair Seating Application
Built as a real-world full-stack learning project using .NET 8

⭐ If you like this project

Give it a ⭐ on GitHub 🙂


---

If you want, I can also:
- Create **API + UI screenshots section**
- Add **Swagger screenshots**
- Prepare **resume-ready project description**
- Convert this into **company submission format**

Just tell me 
