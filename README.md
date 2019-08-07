# BlogDeInvestigacion

## Pasos para correr la aplicación:

1. Clonar la solucion a tu máquina local

2. Si al iniciar la aplicacion no se encuentra el archivo "\roslyn\csc.exe", desisntalar y reinstalar el paquete
"Microsoft.CodeDom.Providers.DotNetCompilerPlatform" desde NuGet Package Manager.

3. Creación de la base de datos
3.1.
  Verificar que **no** exista la base de datos "DbBlog", en caso de que exista borrarla, puede hacerlo desde:
  a) SQL Server Management Studio, con server name (LocalDb)\MSSQLLocalDB
  b) Abrir la solucion en Visual Studio -> Views -> SQL Server Object Explorer
  
3.2.
  Eliminar todas las migraciones (en la carpeta migrations dentro del proyecto, **NO ELIMINAR configuration.cs**)
  
3.3.
  Reconstruir el projecto (Visual Studio -> Build -> Rebuild Solution)
  
3.4.
  En Package Manager Console, correr los siguientes comandos:
  
  Add-Migration NombreDeLaMigracion       
                        Ej: **Add-Migration CleanMigration**
  
  **Update-Database**
  
3.5.
  Iniciar la aplicación para que termine de crear las tablas restantes




## VINCULOS RELEVANTES

GitHub Formatting: 
https://help.github.com/en/articles/basic-writing-and-formatting-syntax

Get Started with Entity Framework 6 Code First:
https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application#create-the-database-context

Working with DbContext: 
https://docs.microsoft.com/en-us/ef/ef6/fundamentals/working-with-dbcontext





