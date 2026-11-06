# GradeManagerPlus

A **Windows desktop grade-management prototype** with separate student and administrator views, grade records, and visual reporting.

**Stack:** C# · Windows Forms · Microsoft Access · OleDb / SQL queries

## Overview

This project explores two distinct workflows:

- **Student view:** view personal grade information.
- **Administrator view:** inspect and manage student records, averages, and charts.

The application uses OleDb to query a local **Microsoft Access (`.accdb`) database**. It is **not** a SQL Server-backed application.

## Project structure

```text
Assignment4.sln                  Visual Studio solution
Assignment4/frmlogin.cs          Login and navigation
Assignment4/frmadmin.cs          Administrator workflow
Assignment4/frmStudentInfo.cs    Student information
Assignment4/frmNewStudent.cs     New-student form
```

## Run and requirements

- Windows with Visual Studio / .NET Framework tooling compatible with the solution
- Microsoft Access Database Engine (ACE OleDb provider)
- A compatible local `.accdb` file with the expected tables

The original code contains an **absolute database path** to the developer's computer, and the database file is not packaged as a portable setup here. Adjust the connection string and supply a suitable local test database before running.

## Important security limitations

This is an early learning project, not a production identity-management implementation. The current login code constructs SQL from form inputs and should be updated to use **parameterized queries**; real-world authentication would also require secure password storage and appropriate authorization checks.

## Next improvements

- Parameterize every SQL query
- Separate data access from UI logic
- Use configurable database connection settings
- Add automated tests and use synthetic demonstration data
