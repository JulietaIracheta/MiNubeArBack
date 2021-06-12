# Configuración del proyecto

-  Renombrar el archivo appsettings.json.example por appsettings.json

- cambiar los siguiente valores por los correspondientes a su base de datos:
```
    - SERVER
    - DBNAME
    - USER
    - PASSWORD
```

- Si quiere utilizar otro puerto, y no el que se levanta por defecto, agregar la siguiente linea a la misma altura que "ConnectionStrings" modificando el valor de PUERTO por el que desee usar como por ejemplo el 60671

```
"Urls": "http://localhost:PUERTO/"
```

- Si utiliza de sistema operativo linux tal vez sea necesario agregar el siguiente parámetro al valor "DevConnection":

```
Integrated Security=false
```

- Ejemplo de appsettings.json

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "Urls": "http://localhost:60671/",
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DevConnection": "Server =localhost; Database=testDB; User Id =sa; Password=1234Cd; Trusted_Connection=True; MultipleActiveResultSets=True;Integrated Security=false"
  }
}
```
