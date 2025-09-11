# Task Tracker Pro – A Blazor Task Management App



## 🚀 Overview

**Task Tracker Pro** is a modern task management dashboard built with Blazor.

This project demonstrates:
- Component-driven architecture
- Clean service abstraction
- State management
- Async programming
- Reusable UI components
- Dependency injection
- Unit testing

---

## ✨ Features

- **Task List:** View all tasks with title, description, status (Pending/Completed), priority (Low/Medium/High), and created timestamp.
- **Add/Edit Task:** Modal form with validation.
- **Toggle Completion:** Mark tasks as completed.
- **Delete Task:** Remove tasks from the list.
- **Sorting:** Tasks sorted by priority and creation date.
- **Validation:** Blazor form validation via DataAnnotations.
- **Responsive UI:** Clean, usable layout with Bootstrap and Blazor components.

---

## ⚙️ Technical Approach

- **Blazor Server:** Modular components for task list, task item, and add/edit form.
- **Domain-Driven Design (DDD):**
  - Core domain entities and aggregates are defined in the service layer.
  - Business logic encapsulated in domain models.
- **Repository Pattern:**
  - Data access abstracted via generic repositories (`IRepository<T>`, `IReadRepository<T>`).
  - Specifications used for querying and sorting.
- **Service Layer:**
  - `ITaskService` interface with async CRUD operations.
  - Dependency injection for testability and separation of concerns.
- **State Management:**
  - Singleton/in-memory service for demo purposes.
  - UI updates automatically on task state changes.
- **Validation:**
  - `DataAnnotationsValidator` and `ValidationMessage` for graceful error handling.
- **Unit Testing:**
  - xUnit tests for service layer using Moq.

---

## 🛠 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or later

### Setup

1. **Clone the repository:**
   ```bash
   git clone https://github.com/JunqiaoDuan/blazor-task-tracker-drin.git
   ```

2. **Configure the database connection:**
   - Update user secrets with your SQL Server connection string.

3. **Apply migrations:**
   ```bash
   dotnet ef database update
   ```

4. **Run the app:**
   ```bash
   dotnet run --project TaskTrackerPro.Web
   ```

5. **Open in browser:**
   - Navigate to [https://localhost:5001](https://localhost:5001) (or the port shown in the console).

---

## 📁 Project Structure

- `TaskTrackerPro.Web` — Blazor UI, components, routing, shared layout.
- `TaskTrackerPro.Service` — Domain entities, interfaces, business logic.
- `TaskTrackerPro.Service.Shared` — Dtos, Helpers, Interfaces.
- `TaskTrackerPro.Infrastructure` — EF Core DbContext, repository implementations, migrations.
- `TaskTrackerPro.Service.UnitTest` — xUnit tests for service layer.

---

## 💡 Assumptions

- The app uses a SQL Server backend for demo purposes.
- DDD and repository pattern are employed for maintainability and testability.
- UI is intentionally minimal to emphasize architecture clarity.

---

## 🚧 Areas for Improvement

- Implement tag system and toast notifications.
- Persist tasks to browser storage (localStorage/IndexedDB).
- Add more comprehensive integration tests.
- Enhance UI/UX and accessibility.

---

## 🧪 How to Run Unit Tests

```bash
dotnet test TaskTrackerPro.Service.UnitTest
```

---

## 🏗 Design Decisions

- **DDD & Repository Pattern:** Promotes separation of concerns, testability, and scalability.
- **Blazor Components:** Enables reusable, maintainable UI.
- **Async Service Layer:** Ensures responsive UI and future scalability.

---

## 📬 Contact

For questions or feedback, please [open an issue](https://github.com/JunqiaoDuan/blazor-task-tracker-drin/issues) or contact me via [GitHub](https://github.com/JunqiaoDuan).

---