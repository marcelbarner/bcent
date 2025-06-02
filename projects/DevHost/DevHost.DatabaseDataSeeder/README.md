# DevHost.DatabaseDataSeeder

**DevHost.DatabaseDataSeeder** is a .NET worker service responsible for seeding sample data into the application's database. It is designed to be run **explicitly from the Aspire dashboard** and cannot be started independently.

This worker provides a set of predefined, hardcoded data and supports optional custom data via JSON files. It is intended for development and testing purposes only.

---

## 🚀 How to Run

This worker **must be started manually via the Aspire dashboard**. It will not run on its own and is not meant to be deployed in production environments.

---

## 📁 Project Structure
```
├── Data/
│ ├── categories.json # (Optional) Custom categories
│ └── accounts/
│ ├── account1.json # (Optional) Custom account data
│ └── account2.json
```

---

## 🧩 Custom Data Seeding

You can add your own sample data by placing custom JSON files in the `Data/` directory. The following types of data are supported:

### 1. Categories

**File:** `Data/categories.json`  
**Format:** JSON array of objects

```json
[
  {
    "id": 2,
    "name": "Salary",
    "type": 0,
    "parentTransactionCategoryId": 1
  }
]
```

- `id` (int): Unique ID for the category (required)
- `name` (string): Category name (required)
- `type` (int): 0 for income, 1 for expense (required)
- `parentTransactionCategoryId` (int): Optional parent category ID

### 2. Accounts and Transactions
**File Path:** Data/accounts/*.json  
**Format:** One file per account

```json
{
  "name": "DKB Giro",
  "transactions": [
    {
      "date": "2023-09-09",
      "purposeOfUse": "Eröffnungssaldo. automatisch erzeugt",
      "amount": 1373.11,
      "transactionCategoryId": 1
    }
  ]
}
```

- `name` (string): Optional name for the account
- `transactions` (array):
  - `date` (string, ISO format): Date of the transaction
  - `purposeOfUse` (string): Optional transaction purpose
  - `amount` (decimal): Transaction amount
  - `transactionCategoryId` (int): ID of a category (can be from hardcoded or custom categories)

## 🛠️ Extending the Seeder
If you want to seed additional entities or change the behavior of the worker, you’ll need to modify the source code of DevHost.DatabaseDataSeeder. Look for the appropriate seeding logic and extend it to support your desired data.

## 📌 Notes
This service is not intended to run independently.

All data seeding is explicit and one-time per run.

Make sure custom JSON files are correctly formatted to avoid runtime errors.

For referencing category IDs, ensure consistency between hardcoded and custom definitions.

## 📞 Support
For any questions or issues, please contact the project maintainers or refer to internal documentation.#

Let me know if you’d like this README to include build/run instructions, developer contribution notes, or Docker support.
