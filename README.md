
# RagProject

A .NET-based RAG (Retrieval-Augmented Generation) application.

## Overview

This project is a practice project focused on building a RAG application using .NET and PostgreSQL.

## Technologies

- C#
- .NET
- ASP.NET Core Minimal API
- PostgreSQL
- Entity Framework Core
- Swagger / OpenAPI

## Architecture

The solution follows Onion Architecture.

```text
RagProject/
├── src/
│   ├── RagProject.Domain/
│   ├── RagProject.Application/
│   ├── RagProject.Infrastructure/
│   └── RagProject.API/
├── tests/
├── RagProject.sln
├── .gitignore
└── README.md
```

## Getting Started

1. Install the required .NET SDK.
2. Install PostgreSQL.
3. Configure the database connection string locally.
4. Run the `RagProject.API` project.
5. Open Swagger to explore the API endpoints.

## Status

Work in progress.
