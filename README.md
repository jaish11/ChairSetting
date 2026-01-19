# Chair Seating Application
<img width="1920" height="1080" alt="Screenshot (224)" src="https://github.com/user-attachments/assets/c339fd56-095e-4e5f-9e7d-c73aa5e02514" />
<img width="1920" height="1080" alt="Screenshot (225)" src="https://github.com/user-attachments/assets/04d779e1-b708-402b-8121-6071b0489981" />
<img width="1920" height="1080" alt="Screenshot (226)" src="https://github.com/user-attachments/assets/216a7ecf-b6d8-484b-99c9-89f8d3024e64" />
<img width="1920" height="1080" alt="Screenshot (227)" src="https://github.com/user-attachments/assets/b98bafec-1d74-41e3-8b37-59d3edeb027c" />
<img width="1920" height="1080" alt="Screenshot (228)" src="https://github.com/user-attachments/assets/226d7a51-6e2e-4bf0-8cef-e49b2e297fa6" />
<img width="1920" height="1080" alt="Screenshot (229)" src="https://github.com/user-attachments/assets/2eb1c6b6-827d-456c-bbce-b141ca4de54a" />
<img width="1920" height="1080" alt="Screenshot (230)" src="https://github.com/user-attachments/assets/7ec3e051-bf38-4979-96d4-2c59decf4586" />
<img width="1920" height="1080" alt="Screenshot (231)" src="https://github.com/user-attachments/assets/79afb2e0-e7a1-4d64-8de3-d406641c82b8" />

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
