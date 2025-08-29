# FinanceApp# 💰 Finance Tracker - Backend

The backend service for the **Finance Tracker App**.  
Provides a RESTful API to manage **expenses, incomes, categories, budgets, and currencies**.  

Built with **C# .NET Core** and **PostgreSQL**, following clean architecture principles.  

---

## 🚀 Features

- 🔑 User authentication & authorization (JWT-based, if implemented)  
- ➕ Add, ✏️ edit, ❌ delete **expenses and incomes**  
- 🗂️ Manage **categories** (income & expense)  
- 📊 Track **balance** and **budget per category**  
- 💱 Multi-currency support (at least 2 currencies)  

---

## 🛠️ Tech Stack

- **Language:** C#  
- **Framework:** .NET 7 (or version you’re using)  
- **Database:** PostgreSQL (via Entity Framework Core)  
- **Architecture:** REST API, layered architecture  
- **Tools:** Swagger for API docs, Docker (optional for DB)  

---

## 📦 Installation & Setup

### 1. Clone the Repository
```bash
git clone https://github.com/yourusername/finance-tracker-backend.git
cd finance-tracker-backend
2. Configure the Database
Ensure PostgreSQL is installed and running

Create a new database (e.g. finance_tracker_db)

Update the connection string in appsettings.json:

json
Copy code
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=finance_tracker_db;Username=postgres;Password=yourpassword"
}

3. Apply Migrations
bash
Copy code
dotnet ef database update

4. Run the Backend
bash
Copy code
dotnet run


The API will be available at:
👉 https://localhost:5001 (HTTPS)
👉 http://localhost:5000 (HTTP)

📖 API Documentation
Swagger UI is enabled for easy exploration.
Once running, visit:

👉 https://localhost:5001/swagger

Main Endpoints
Expenses & Incomes
GET /api/transactions → Get all transactions

POST /api/transactions → Add new transaction

PUT /api/transactions/{id} → Update transaction

DELETE /api/transactions/{id} → Delete transaction

Categories
GET /api/categories → List categories

POST /api/categories → Create category

Budgets
GET /api/budgets → View budgets

POST /api/budgets → Create budget

Currencies
GET /api/currencies → Supported currencies

🧪 Running Tests
bash
Copy code
dotnet test

🤝 Contributing
Pull requests are welcome! Please open an issue first to discuss any major changes.

📄 License
This project is licensed under the MIT License.

👤 Author
Giuliano Ricca