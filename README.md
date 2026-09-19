# WpfAppMVVM

WpfAppMVVM is a WPF desktop application to showcase my skills for MVVM. This project uses SQLite and EF Core so no database api or authentication is needed.

## Key Features

- MVVM structure for easy extendability
- List of employees stored in SQLite database
- An add employee window

  ## Project Structure

  - `Commands/` - Relay command used throughout this project to bind buttons to commands
  - `DataAccess/` - Data context and data service used to support create function in employee database
  -  `Models/` - Models stored in SQLite database
  -  `ViewModel/` - View models used as a data context for my XAML windows
  -  `Views/` - The XAML windows used in application
 
  ## Requirements

  - Windows
  - .NET 10
 
  ## Build and run steps

  1. Open `WpfAppMVVM.slnx` in IDE of choice (with WPF support).
  2. Restore NuGet packages.
  3. Build the solution
  4. Run the project

 Note: Please make sure a MvvmVang.db file is created in the project root. This should automatically happen within the MainWindow constructor.
