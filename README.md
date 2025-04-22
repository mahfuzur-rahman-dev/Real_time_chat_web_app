# 💬 Real-Time Chat Web App (ASP.NET Core MVC)

This is a **Real-Time Chat Web Application** built using **ASP.NET Core MVC**. The project is fully functional with a robust architecture and includes modern web development practices like **SignalR**, **Authentication & Authorization**, **Entity Framework Core**, **Identity Framework**, and **Unit of Work** with **Repository Pattern**.

## 🚀 Features

- ✅ Real-time messaging using **SignalR**
- ✅ User authentication & authorization
- ✅ Register, login, logout, change password
- ✅ Add friends and chat individually
- ✅ Secure communication and session management
- ✅ Repository & Unit of Work patterns for clean architecture
- ✅ Database integration using **Entity Framework Core**
- ✅ Role-based access using **ASP.NET Identity**
- ✅ Modern UI with **Bootstrap**, **jQuery**, and custom **CSS/JS**

## 📸 Screenshots

1.
![image](https://github.com/user-attachments/assets/6a4afaf9-78bd-4481-930b-c4b03a83f1c4)
2.
![image](https://github.com/user-attachments/assets/3e83d45a-fc18-40cc-ac62-9ab892f9d144)
3.
![image](https://github.com/user-attachments/assets/30bb875e-960d-4b73-9788-6716f0ed3499)


## 🧰 Technologies Used

- **ASP.NET Core MVC**
- **Entity Framework Core**
- **ASP.NET Core Identity**
- **SignalR** for real-time communication
- **Repository Pattern** and **Unit of Work**
- **SQL Server** (or your choice of DB)
- **Bootstrap**, **CSS**, **JavaScript**, **jQuery**

## 📦 Project Structure

```bash
📁 YourSolution
│
├── 📁 Web (UI Layer - MVC)
├── 📁 Service (Business Logic Layer)
├── 📁 DataAccess (Repository & EF Core DbContext)
├── 📁 Models (Entity Models)
├── 📁 ApplicationIdentity (Identity & Authentication)
├── 🗃️ SQL Server Database
```

## 🔧 Setup & Installation

1. Clone the repository
   ```bash
   git clone https://github.com/mahfuzur-rahman-dev/Real_time_chat_web_app.git
   cd real-time-chat-app
   ```

2. **Important Note**: Move the `.env` file from the root documents folder to the Web project with database name and server info for database connection.

3. Restore dependencies
   ```bash
   dotnet restore
   ```

4. Update database
   ```bash
   dotnet ef database update
   ```

5. Run the application
   ```bash
   dotnet run --project Web
   ```

## 👨‍💻 Usage

1. Register a new account or login with existing credentials
2. Add friends using their username or email
3. Start chatting in real-time!

## 🏗️ Architecture

The application follows a layered architecture:

- **Web Layer**: MVC controllers, views, SignalR hubs
- **Service Layer**: Business logic and application services
- **Data Access Layer**: Repository implementations and EF Core context
- **Models**: Entity models and DTOs
- **Application Identity**: Authentication and authorization

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 📞 Contact

Your Name - [mahfuzur.dev@gmail.com](mailto:mahfuzur.dev@gmail.com)

Project Link: https://github.com/mahfuzur-rahman-dev/Real_time_chat_web_app.git
