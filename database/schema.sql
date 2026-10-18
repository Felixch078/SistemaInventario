CREATE DATABASE SistemaInventario;
GO

USE SistemaInventario;
GO

CREATE TABLE Categoria (
    Id int primary key identity(1,1),
    Nombre varchar(100) not null,
    Descripcion varchar(500) not null,
    Activo bit not null default 1,
    FechaCreacion datetime not null default getdate(),
    FechaModificacion datetime not null default getdate()
);
GO

create table CategoriaFoto (
    Id int identity(1,1) primary key,
    CategoriaId int not null,
    Ruta varchar(500) not null,
    constraint fk_foto_cat foreign key (CategoriaId) references Categoria(Id)
);
GO

CREATE TABLE Suplidor (
    Id int primary key identity(1,1),
    NombreEmpresa varchar(150) not null,
    NombreContacto varchar(150) not null,
    Telefono varchar(15) not null,
    Email varchar(100) not null,
    SitioWeb varchar(200) null,
    Activo bit default 1,
    FechaCreacion datetime default getdate(),
    FechaModificacion datetime default getdate()
);
GO

CREATE TABLE Producto (
    Id int identity(1,1) primary key,
    Nombre varchar(150),
    Precio decimal(12,2),
    CategoriaId int,
    SuplidorId int,
    Activo bit default 1,
    FechaCreacion datetime,
    FechaModificacion datetime,
    FOREIGN KEY (CategoriaId) REFERENCES Categoria(Id),
    FOREIGN KEY (SuplidorId) REFERENCES Suplidor(Id),
    check (Precio > 0)
);
GO

CREATE UNIQUE INDEX idx_cat_nombre ON Categoria(Nombre);
CREATE UNIQUE INDEX idx_sup_nombre ON Suplidor(NombreEmpresa);
GO