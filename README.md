# API-Libreria
API desarrollada en .net core, creado a partir de una Base de datos hecha en SQL server

Contexto
La librería Siglo XXI, es una nueva libreríacon todo tipo de libros. 
Queremos crear nuestra app web, para que los clientes puedan conocer nuestro catálogo.Esta primera versión los usuarios podrán ver el catálogo completo de los libros, y consultar del detalle de un libro específico.

Requisitos
Entidad Libro(book)
•id:number
•title: string•chapters: number –Representa el número de capítulos del libro.
•pages: number –Representa la cantidad de páginas.
•price: number –Precio del libro
Entidad Autor (author)
•id: number
•name: string
Debe existir una relación de 1 a muchos entre autoresy libros.
API: 
Deberás decrear los siguientesendpoints:
1.Nuevo Libro:Creará un nuevo libro, aportando todos sus datos incluido el autor.
2.Obtener todos los libros: Deberá devolver un listado de libros con sus autores.
3.Consultar libro:Deberá devolver todos los datos de un libro en específico con base a su id.
4.Crear un autor:Creará un nuevo autor.
5.Obtener todos los autores:Deberá devolver un listado de todos los autores con los libros que tengan.6.Generar una vista htmlen la que se muestre el listado de libros, con todos sus datos. 
Utilizando JavaScript para realizar la petición (fetch) de los datos.
