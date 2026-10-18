# Sistema de Inventario

Aplicación de escritorio desarrollada en Windows Forms para la gestión de Categorías, Suplidores y Productos. El proyecto una una arquitectura por capas (N-Capas), principios de POO, uso de genéricos, LINQ y patrones de diseño.

##Requisitos Previos.
- SQL Server 
- Paquete NuGet: `Microsoft.Data.SqlClient`.

## Instrucciones de Instalación

1. **Clonar el repositorio:**
   Descarga o clona este repositorio en tu computadora.
2. **Configurar la Base de Datos:**
   - Abre SQL Server Management Studio (SSMS).
   - Ejecuta el script `schema.sql` (ubicado en la carpeta `/database`).
   - Ejecuta el script `datos.sql` para insertar los datos de prueba.
3. **Configurar la Cadena de Conexión:**
   - Abre la solución en Visual Studio.
   - Ve al proyecto `SistemaInventario.AccesoDatos` y abre el archivo `ConexionDb.cs`.
   - Modifica el `Server` en la cadena de conexión para que apunte a tu instancia local de SQL Server (e
4. **Compilar y Ejecutar:**
   - Establece el proyecto `SistemaInventario.Presentacion` como proyecto de inicio.
   - Presiona `F5` o haz clic en "Iniciar" para ejecutar la aplicación.

## Arquitectura y Patrones
El sistema está dividido en 4 proyectos:
- **Entidades:** Clases del dominio (`Categoria`, `Suplidor`, `Producto`).
- **AccesoDatos:** Repositorios ADO.NET y el patrón **Singleton** para la conexión (`ConexionDb`).
- **LogicaNegocio:** Servicios, validaciones y las 5 consultas LINQ. 
- **Presentacion:** Formularios de Windows Forms. 

## Capturas de Pantalla

**1. Menú Principal**
<img width="959" height="506" alt="Captura de pantalla 2026-10-18 193036" src="https://github.com/user-attachments/assets/4100bade-4cbb-478e-8182-d1755a045a5c" />


**2. Listado de Productos y Filtros**
<img width="841" height="395" alt="Captura de pantalla 2026-10-18 193103" src="https://github.com/user-attachments/assets/2610a76e-6fcd-4d28-b305-6f16991191f0" />


**3. Papelera (Borrado Lógico)**
<img width="659" height="348" alt="Captura de pantalla 2026-10-18 193111" src="https://github.com/user-attachments/assets/457037cc-e027-460b-81c5-e00a06c7c18a" />


**4. Reportes LINQ**
<img width="744" height="482" alt="Captura de pantalla 2026-10-18 193125" src="https://github.com/user-attachments/assets/712ad067-a61f-4858-aa3a-207a957c442f" />
