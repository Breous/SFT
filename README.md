# Sustainable Fashion Tracker (SFT)

**SFT** is a web-based application that empowers users to log, track, and reflect on their clothing purchases through a sustainability lens. Built with ASP.NET Core Razor Pages, this project helps users make more conscious fashion choices by tracking materials, brand info, cost, and eco-ratings.

---

## Features

- **User Registration & Login**  
  Secure user authentication using ASP.NET Core Identity.

- **Profile Dashboard**  
  Displays user details, sustainability level, purchase history, and key stats like total spent, total purchases, and average rating.

- **Log a Purchase**  
  Users can record purchases by entering item name, brand, material, price, and a sustainability rating (1–5).

- **Download Purchases**  
  Users can export their entire purchase history to a file for offline reference or analysis.

- **Responsive Design**  
  Simple, clean UI with a soft color palette and a custom sustainability tree logo that reinforces the theme.

---

## Capstone Feature List (Required 3+)

| Feature | Description | Location |
|--------|-------------|----------|
| **Regex Validation** | Validates that Sustainability Level is either `Low`, `Medium`, or `High`. | `Models/User.cs` – Line 10 |
| **List of Purchases** | Purchase history dynamically displayed from a user-specific list. | `Pages/Profile.cshtml` – Line ~50 |
| **File Writing (Export)** | Allows users to export their purchases. | `Pages/Profile.cshtml.cs` – OnPostExportAsync() |
| **User Authentication** | ASP.NET Core Identity with custom properties. | `Program.cs`, `AppDbContext.cs`, `User.cs` |

---

## Technologies

- **ASP.NET Core 8.0**
- **Razor Pages**
- **Entity Framework Core (SQLite)**
- **ASP.NET Core Identity**
- **Bootstrap 5**
- **C# 12**
- **DB Browser for SQLite** (for testing/debugging)

---

## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Visual Studio 2022 or later (recommended)
- Git

### Run Locally

```bash
git clone https://github.com/Breous/SFT.git
cd SFT
dotnet ef database update # apply migrations
dotnet run

Then visit https://localhost:xxxx


---

Screenshots
![SFT Register Page](https://github.com/user-attachments/assets/0c7b1b23-f430-40ea-bb3f-b224395f3506)
![SFT Home Page](https://github.com/user-attachments/assets/86abeda2-423d-4989-8df8-7508ce556e1a)
![SFT Log Page](https://github.com/user-attachments/assets/d885d61f-e278-4f3f-b0a6-90d2cfe40ea6)






---

Developer

Created by: Breous
Capstone Project for: Code:You
Demo Day Ready: Yes


---

Future Ideas

Brand rating database

Community tips feed

Purchase impact calculator (carbon, water, ethics)



---

License

This project is part of a learning portfolio and is open to reuse with attribution.
