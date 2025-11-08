# 🛒 ShoppingCartApp

[![.NET 9](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-Razor%20Pages-512BD4)](https://docs.microsoft.com/aspnet/core)
[![License](https://img.shields.io/badge/License-Free%20to%20Use-green.svg)](LICENSE)

> A modern e-commerce shopping cart application built with ASP.NET Core and .NET 9

## 📋 Table of Contents

- [Overview](#-overview)
- [Objectives](#-objectives)
- [Features](#-features)
- [Technology Stack](#-technology-stack)
- [Getting Started](#-getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Running the Application](#running-the-application)
- [Project Structure](#-project-structure)
- [Configuration](#-configuration)
- [Usage](#-usage)
- [Architecture](#-architecture)
- [Testing](#-testing)
- [Contributing](#-contributing)
- [Roadmap](#-roadmap)
- [Support](#-support)
- [Acknowledgments](#-acknowledgments)

## 🎯 Overview

**ShoppingCartApp** is a full-featured e-commerce shopping cart solution built using ASP.NET Core for the backend and rendered with Razor Pages targeting .NET 9. This application provides a seamless shopping experience with a clean, intuitive interface for browsing products, managing cart items, and completing purchases.

The application follows modern web development best practices and leverages the latest features of .NET 9 to deliver a high-performance, scalable solution suitable for small to medium-sized e-commerce platforms.

## 🎓 Objectives

The primary objectives of this project are to:

- ✅ Provide a robust, production-ready shopping cart implementation
- ✅ Demonstrate best practices for ASP.NET Core Razor Pages development
- ✅ Showcase modern .NET 9 features and patterns
- ✅ Offer an extensible architecture for future enhancements
- ✅ Deliver an intuitive user experience for both customers and administrators
- ✅ Maintain clean, well-documented code for educational purposes

## ✨ Features

### 🙎 Customer Features
- 🛍️ Browse product catalog with filtering and search
- 🛒 Add/remove items to/from shopping cart
- 📦 View cart summary and item details
- 💳 Secure checkout process
- 📱 Responsive design for mobile and desktop
- 🔐 User authentication and authorization

## Features To be implemented in future releases

### 🎛️ Admin Features
- 📊 Product management (CRUD operations)
- 📈 Order tracking and management
- 👥 Customer management
- 📉 Basic analytics dashboard

 ### 🔎 Search & Filter 
 
 - Use the search bar and category filters to find products

## 🛠️ Technology Stack

| Technology | Version | Purpose |
|------------|---------|---------|
| .NET | 9.0 | Runtime framework |
| ASP.NET Core | 9.0 | Web framework |
| Razor Pages | 9.0 | UI framework |
| Entity Framework Core | 9.0 | ORM |
| SQL Server | Latest | Database |
| Bootstrap | 5.x | CSS framework |

## 🚀 Getting Started

### Prerequisites

Before you begin, ensure you have the following installed:

- ✔️ [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) or later
- ✔️ [Visual Studio 2022](https://visualstudio.microsoft.com/) (17.8+) or [Visual Studio Code](https://code.visualstudio.com/)
- ✔️ [SQL Server](https://www.microsoft.com/sql-server) (LocalDB, Express, or higher)
- ✔️ Git for version control

### Installation

1. **Clone the repository**

   ```bash
   git clone https://github.com/yourusername/shoppingcartapp.git
   cd shoppingcartapp
   ```

2. **Restore dependencies**

   ```bash
   dotnet restore
   ```

3. **Update database connection string**

   Edit `appsettings.json` and configure your SQL Server connection:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ShoppingCartAppDb;Trusted_Connection=True;"
   }
   ```

4. **Apply database migrations**

   ```bash
   dotnet ef database update
   ```

5. **Seed initial data (optional)**

   To add sample data to the database, run the following command:

   ```bash
   dotnet run seed
   ```

### Running the Application

1. **Using .NET CLI**

   ```bash
   dotnet run
   ```

2. **Using Visual Studio**
   - Open `ShoppingCartApp.sln`
   - Press `F5` or click the "Run" button

3. **Access the application**
   - Navigate to `https://localhost:5001` (or the port shown in the console)
   - Default admin credentials:
     - Username: `admin@shoppingcart.com`
     - Password: `Admin@123`

## 📁 Project Structure

```
ShoppingCartApp
│
├───src
│   ├───ShoppingCartApp
│   │   ├───Areas
│   │   ├───Components
│   │   ├───Data
│   │   ├───Migrations
│   │   ├───Models
│   │   ├───Pages
│   │   ├───Services
│   │   └───wwwroot
│   │
│   └───ShoppingCartApp.Tests
│
├───.gitignore
├───LICENSE
├───README.md
└───ShoppingCartApp.sln
```

## ⚙️ Configuration

Key configuration options in `appsettings.json`:

- `ConnectionStrings`: Database connection settings
- `Logging`: Logging configuration
- `AppSettings`: Custom application settings

## 📖 Usage

### For Customers

1. **Browse Products**: Navigate to the home page to view available products
2. **Add to Cart**: Click "Add to Cart" on any product
3. **View Cart**: Click the cart icon to review your items
4. **Checkout**: Proceed to checkout and complete your purchase
