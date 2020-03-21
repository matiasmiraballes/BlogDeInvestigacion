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
  
3.2
  Verificar que exista la carpeta "App_Data" dentro de la carpeta donde se encuentra ubicado el proyecto, de otra forma la aplicación dará un error a la hora de intentar de crear la base de datos

3.3.
  Eliminar todas las migraciones (en la carpeta migrations dentro del proyecto, **NO ELIMINAR configuration.cs**)
  
3.4.
  Reconstruir el projecto (Visual Studio -> Build -> Rebuild Solution)
  
3.5.
  En Package Manager Console, correr los siguientes comandos:
  
  **Add-Migration** NombreDeLaMigracion       
                        Ej: **Add-Migration FirstMigration**
  
  **Update-Database**
  
  **NOTA:** Debido a una inconsistencia con el comando RESEED de SQL Server, **Update-Database puede fallar cuando se ejecuta por primera vez** en una base de datos recien creada, en cuyo caso deberá ejecutar este comando una segunda vez.
  
3.6.
  Iniciar la aplicación para que termine de crear las tablas restantes


# AGREGANDO TABLAS A LA BASE DE DATOS

Para agregar tablas a la base de datos seguir los siguientes pasos:

#### CREAR EL MODELO CORRESPONDIENTE

Para ello debemos agregar una clase dentro de la carpeta **"/Models"** con el nombre del modelo deseado, los modelos siguen un formato similar al siguiente:
```
namespace BlogDeInvestigacion.Models
{
    public class Laboratorio
    {
        [Key]
        public int IdLaboratorio { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }
        ...
    }
}
```
**NOTA**: [Key], [StringLength(50)] son etiquetas que se utilizan para especificar caracteristicas de las propiedades, se pueden buscar por el nombre **Data Annotations** 

#### ACTUALIZAR EL METODO SEEDER

Dentro de la clase "/Migrations/Configuration.cs" se encuentra un método llamado Seed. Este método se ejecuta luego de actualizar la base de datos
co el comando "Update-Database". Las migraciones no plasmarán modelos a la base de datos a menos que se utilicen en alguna seccion del código.
Es recomendable agregar registros a la base de datos aquí, de esta forma las tablas siempre estarán creadas y con información para poder hacer pruebas.

** Ejemplo de registros "laboratorios"
```
var laboratorios = new List<Laboratorio>
{
new Laboratorio{Nombre="LINES",Descripcion="LINES - Laboratorio de Ingeniería en Sistemas de Información, Misión: Efectuar desarrollos de avanzada e investigación aplicada, sobre temas relacionados con las necesidades y características informáticas del sistema productivo local, nacional e internacional. En temas relacionados a desarrollo de software a medida, auditorias, consultoría, redes y comunicaciones."},
new Laboratorio{Nombre="LINSI",Descripcion="LINSI - Laboratorio de Innovaciones en sistemas de Información, Misión: Dar Apoyo académico en áreas de competencia del Departamento de Sistemas de Información (DSI) que componen el Departamento de Ingeniería en Sistemas de Información, además de desarrollar actividades de investigación y desarrollo de distintos proyectos tecnológicos."},
...
};

laboratorios.ForEach(l => context.Laboratorios.Add(l));
context.SaveChanges();
```
#### ACTUALIZAR LA BASE DE DATOS CON ENTITY FRAMEWORK

Una vez agregado el modelo y actualizado el seeder, solo queda correr los comandos para actualizar la base de datos. Asegurese de que las entradas que se intentan agregar a la base de datos cumplan con los tipos/restricciones asignados:

1. **Add-Migration NombreDeLaMigracion**
2. **Update-Database**


## VINCULOS RELEVANTES

GitHub Formatting: 
https://help.github.com/en/articles/basic-writing-and-formatting-syntax

Get Started with Entity Framework 6 Code First:
https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application#create-the-database-context

Working with DbContext: 
https://docs.microsoft.com/en-us/ef/ef6/fundamentals/working-with-dbcontext

Info About IdentityDbContext:
https://stackoverflow.com/questions/19902756/asp-net-identity-dbcontext-confusion
https://github.com/TypecastException/AspNet-Identity-2-Extensible-Project-Template



