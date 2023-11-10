create database libreria
-- Crear la tabla Autor
CREATE TABLE Autor (
    autor_id INT PRIMARY KEY,
    nombre NVARCHAR(255)
);

-- Crear la tabla Libro con una relación de 1 a muchos con Autor
CREATE TABLE libro (
    id_libro INT PRIMARY KEY,
    titulo NVARCHAR(255),
    capitulos INT,
    paginas INT,
    precio INT,
    id_autor INT,
    FOREIGN KEY (id_autor) REFERENCES Autor(autor_id)
);
