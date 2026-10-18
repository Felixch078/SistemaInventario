USE SistemaInventario;
GO

insert into Categoria (Nombre, Descripcion) values 
('Electrónica', 'Equipos electronicos y accesorios'),
('Ropa', 'Prendas de vestir en general'),
('Hogar', 'Articulos para la casa y cocina'),
('Deportes', 'Equipos deportivos'),
('Juguetes', 'Juguetes para niños');

insert into Categoria (Nombre, Descripcion, Activo) values 
('Obsoleta', 'Esta categoria ya no se usa', 0);
GO

insert into Suplidor (NombreEmpresa, NombreContacto, Telefono, Email, SitioWeb) values
('TechStore SRL', 'Juan Perez', '809-555-1111', 'juan@techstore.com', 'https://techstore.com'),
('ModaTotal', 'Ana Gomez', '829-555-2222', 'ana@modatotal.com', null),
('HogarPlus', 'Luis Martinez', '849-555-3333', 'luis@hogarplus.com', 'https://hogarplus.com'),
('SportsRD', 'Marta Diaz', '809-555-4444', 'marta@sportsrd.com', null),
('El Sol', 'Carlos Ruiz', '829-555-5555', 'carlos@elsol.com', 'https://elsol.com');

insert into Suplidor (NombreEmpresa, NombreContacto, Telefono, Email, Activo) values
('Proveedor Viejo', 'Pedro', '809-000-0000', 'pedro@viejo.com', 0);
GO

insert into Producto (Nombre, Precio, CategoriaId, SuplidorId) values 
('Laptop HP', 45000.00, 1, 1),
('Mouse Logitech', 850.00, 1, 1),
('Monitor 24 pulgadas', 12000.00, 1, 1),
('Teclado Mecanico', 3200.00, 1, 1),
('Audifonos Sony', 5500.00, 1, 1),
('Camisa Polo', 1200.00, 2, 2),
('Pantalon Jeans', 2500.00, 2, 2),
('Sudadera', 1800.00, 2, 2),
('Zapatos deportivos', 3500.00, 2, 2),
('Sarten', 1800.00, 3, 3),
('Juego de sabanas', 2200.00, 3, 3),
('Licuadora', 3500.00, 3, 3),
('Set de vasos', 750.00, 3, 3),
('Balon de futbol', 950.00, 4, 4),
('Raqueta de tenis', 4500.00, 4, 4),
('Pesas 10 libras', 1500.00, 4, 4),
('Lego Star Wars', 3200.00, 5, 5),
('Muñeca Barbie', 950.00, 5, 5);

insert into Producto (Nombre, Precio, CategoriaId, SuplidorId, Activo) values 
('Tablet Samsung', 9500.00, 1, 1, 0),
('Chaqueta de cuero', 4200.00, 2, 2, 0);
GO

insert into CategoriaFoto (CategoriaId, Ruta) values 
(1, 'C:\fotos\electronica.jpg'),
(2, 'C:\fotos\ropa.png');
GO