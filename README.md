# 📈 Stock Trading Dashboard

Stock Trading Dashboard is a responsive web application built with ASP.NET Core 8 and Razor Pages that enables users to monitor stock performance, simulate trades, and manage a virtual portfolio. It integrates seamlessly with third-party stock APIs to deliver real-time market data, making it ideal for developers, analysts, or anyone exploring financial applications.

## ✨ Features

- 🔍 Searchable stock list with real-time filtering and autocomplete
- 📊 Live quotes, historical charts, and performance metrics
- 💼 Simulated trading with portfolio tracking and profit/loss analysis
- 📝 Add/Edit/Delete watchlist entries with validation
- 📁 Clean, responsive UI using Bootstrap 5 and Chart.js
- 🛡️ Secure architecture with ASP.NET Identity integration (optional)
- 🔄 API caching and retry logic for robust external data handling
- 📤 Scalable design ready for future enhancements like real trading, alerts, or ML predictions

## 🧰 Tech Stack

- **Frontend**: HTML, CSS, Bootstrap, Razor Pages 
- **Backend**: ASP.NET Core 8, C#, Entity Framework Core  
- **Database**: SQL Server (or SQLite for lightweight setups)  
- **API Provider**: Finnhub, Alpha Vantage, or IEX Cloud (configurable)  
- **Tools**: Visual Studio 2022+, Git, GitHub  

## 🚀 ASP.NET Core Features Used

This project demonstrates a comprehensive use of ASP.NET Core 8 capabilities, including:

- 🔐 **Authentication & Authorization** — Secure access control using ASP.NET Identity and optional JWT tokens  
- 📦 **JWT Integration** — Stateless authentication for future API endpoints  
- 📈 **Logging & Diagnostics** — Integrated logging with Serilog and structured error tracking  
- 🧩 **Middleware Pipeline** — Custom middleware for API rate limiting and performance monitoring  
- 🛠️ **Dependency Injection** — Service-based architecture for clean separation of concerns  
- 🗂️ **Razor Pages & Layouts** — Modular UI with shared layouts and partial views  
- 🧪 **Model Validation** — Robust input validation using data annotations  
- 🧵 **Routing & Endpoint Mapping** — RESTful routing and page-based navigation  
