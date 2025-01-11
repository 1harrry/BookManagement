# Book Management System

## Overview
This project is a Book Management System that allows users to manage a collection of books. The system includes the following features:

- CRUD operations for managing books (Create, Read, Update, Delete).
- Price and rating calculations for books.
- A dashboard for displaying book statistics such as total books, average rating, and books by genre.

## Features
- **CRUD Operations:** Create, Read, Update, and Delete books.
- **Price Calculation:** Shows the final price for books based on business logic.
- **Rating:** Allows users to rate books.
- **Dashboard:** Displays summary statistics about the books.

## Project Structure

### Backend (API):
- **Controllers:** Manages HTTP requests and responses for the API. Example: `BooksController` for book operations.
- **Services:** Contains business logic for handling books, such as adding or updating books. Example: `BookService`.
- **Repositories:** Abstracts database operations and interacts with the database. Example: `BookRepository`.
- **To Make API Project Running:** Set `launchBrowser` to `False` in `launchSettings.json`.

### Frontend (Blazor):
- **Pages:** Contains Blazor pages for displaying and managing books, such as:
  - **Index.razor:** Displays the list of books.
  - **Create.razor:** Provides a form to create a new book.
  - **Edit.razor:** Provides a form to update book details.
  - **Delete.razor:** Confirms and deletes a book.
- **Components:** Reusable components for displaying book information and status badges.

### Testing:
- **Unit Tests:** The service layer of the API is tested using xUnit and Moq.
- **Testing Framework:** xUnit is used for unit testing, with mock dependencies for the service layer.

## Installation

### Prerequisites
Before you begin, make sure you have the following installed on your machine:

- [.NET SDK](https://dotnet.microsoft.com/download) (version 8 or higher)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or use SQLite for development)
- A code editor like [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

### Steps to Run the Project:

1. **Clone the repository:**
   To clone the repository from GitHub, open your terminal or command prompt and run:
   ```bash
   git clone <https://github.com/1harrry/BookManagement.git>
