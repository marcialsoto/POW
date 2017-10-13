# ACTIVAR MIGRACIONES AUTOMATICAS
Ir a Menú Herramientas y seleccionar el submenú Adinistrador de Paquetes NuGet opcion Consola e ingresar en la consola:

```
Enable-Migrations -ContextTypeName nombre_de_contexto -EnableAutomaticMigrations
```

En donde **nombre_de_contexto** es el nombre asignado a tu contexto.

El comando crea una carpeta Migrations. Abrir el archivo contenido en dicha carpeta de nombre **Configuration.cs** y agregar el siguiente codigo en el método **configuration()**

```
 //Activa las migraciones automaticas
 AutomaticMigrationDataLossAllowed = true;
```

Guardar y abrir el archivo Global.asax y en el metodo **Application_Start()**

```
//Verifica si el modelo ha cambiado
Database.SetInitializer(new MigrateDatabaseToLatestVersion<Models.nombre_de_contexto, Migrations.Configuration>());
 ```

En donde **nombre_de_contexto** es el nombre asignado a tu contexto.



