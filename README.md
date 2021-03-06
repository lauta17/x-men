# Mutant Detector Service

Magneto quiere reclutar la mayor cantidad de mutantes para poder luchar
contra los X-Men.

Te ha contratado a ti para que desarrolles un proyecto que detecte si un
humano es mutante basándose en su secuencia de ADN.

Para eso te ha pedido crear un programa con un método o función con la siguiente firma (En
alguno de los siguiente lenguajes: 
      
● Java / Golang / C-C++ / Javascript (node) / Python / Ruby):

      boolean isMutant(String[] dna); // Ejemplo Java
En donde recibirás como parámetro un array de Strings que representan cada fila de una tabla
de (NxN) con la secuencia del ADN. Las letras de los Strings solo pueden ser: (A,T,C,G), las
cuales representa cada base nitrogenada del ADN.

Ejemplos:

No-Mutante

|||||||
|-|-|-|-|-|-|
|A|T|G|C|G|A|
|C|A|G|T|G|C|
|T|T|A|T|T|T|
|A|G|A|C|G|G|
|G|C|G|T|C|A|
|T|C|A|C|T|G|

Mutante

|||||||
|-|-|-|-|-|-|
|A|T|G|C|G|A|
|C|A|G|T|G|C|
|T|T|A|T|G|T|
|A|G|A|A|G|G|
|C|C|C|C|T|A|
|T|C|A|C|T|G|

Sabrás si un humano es mutante, si encuentras **más de una secuencia de cuatro letras
iguales** , de forma oblicua, horizontal o vertical.

**Ejemplo (Caso mutante):**

String[] dna = {"ATGCGA","CAGTGC","TTATGT","AGAAGG","CCCCTA","TCACTG"};
En este caso el llamado a la función isMutant(dna) devuelve “true”.
Desarrolla el algoritmo de la manera más eficiente posible.


**Desafíos:**

- Programa (en cualquier lenguaje de programación) que cumpla con el método pedido por Magneto.

- Crear una API REST, hostear esa API en un cloud computing libre (Google App Engine,
Amazon AWS, etc), crear el servicio “/mutant/” en donde se pueda detectar si un humano es
mutante enviando la secuencia de ADN mediante un HTTP POST con un Json el cual tenga el
siguiente formato:
            
       POST → /mutant/
       {
          “dna”:["ATGCGA","CAGTGC","TTATGT","AGAAGG","CCCCTA","TCACTG"]
       }

   En caso de verificar un mutante, debería devolver un HTTP 200-OK, en caso contrario un 403-Forbidden

- Anexar una base de datos, la cual guarde los ADN’s verificados con la API.
   Solo 1 registro por ADN.

   Exponer un servicio extra “/stats” que devuelva un Json con las estadísticas de las verificaciones de ADN: 
    
      {“count_mutant_dna”:40, “count_human_dna”:100: “ratio”:0.4}
    
   Tener en cuenta que la API puede recibir fluctuaciones agresivas de tráfico (Entre 100 y 1 millón de peticiones por segundo).

   Test-Automáticos, Code coverage > 80%.

# Entregar:

  ● Código Fuente en repositorio github.
  
  ● Instrucciones de cómo ejecutar el programa o la API. (README de github).
  
  ● URL de la API.

# Intrucciones

1. Para utilizar de forma local debemos bajar el codigo de GitHub.
2. Descargar la sdk de netcore 3.1 https://dotnet.microsoft.com/download/dotnet-core/3.1
3. Abrir powershell y ejecutar los siguientes comandos:

       $ dotnet build .
       $ dotnet publish -c Release

4. Hostear la web api en el IIS o ejecutar:
      
       $ docker build .
       $ docker run .

5. Podemos utilizar las sigueintes llamadas http:

       GET url/stats/ --> Response {“count_mutant_dna”:40, “count_human_dna”:100: “ratio”:0.4}
       
       POST url/mutant/ --> Request { “dna”:["ATGCGA","CAGTGC","TTATGT","AGAAGG","CCCCTA","TCACTG"] }

# Arquitectura del proyecto

  ● Services: Capa encargada de contener los controladores para recibir las solicitudes http.
 
  ● Application: Se encarga de orquestar la logica de negocio y las llamadas a los repositorios.
 
  ● Domain: Contiene la logica y entidades de negocio.
 
  ● IoC: Contiene las inyecciones de dependencias.
 
  ● DB: Contiene el acceso a la base de datos.

# Tecnologias utilizadas

      Dotnet 3.1
      MongoDB Atlas DataBase
      XUnit unit testing
      Hosteado en AWS Elastic Beanstalk 
