CREATE DATABASE TWMP;

USE TWMP;

CREATE TABLE Categoria (
	twmp_IdCategoria INT IDENTITY PRIMARY KEY NOT NULL,
	twmp_CategoriaProduto VARCHAR(50)
);

CREATE TABLE Permissao(
	twmp_IdPermissao INT IDENTITY PRIMARY KEY NOT NULL,
	twmp_TipoUsuario VARCHAR (50)
);

CREATE TABLE Usuario (
	twmp_IdUsuario INT IDENTITY PRIMARY KEY NOT NULL,
	twmp_Nome VARCHAR(50),
	twmp_Email VARCHAR(50) UNIQUE,
	Twmp_Senha VARCHAR(10),
	Twmp_ImgUsuario VARCHAR(500),
	twmp_IdPermissao INT FOREIGN KEY REFERENCES Permissao(twmp_IdPermissao)
);

CREATE TABLE Produto (
	twmp_IdProduto INT IDENTITY PRIMARY KEY NOT NULL,
	twmp_Nome VARCHAR(50),
	twmp_Descricao VARCHAR(250),
	twmp_Preco MONEY,
	twmp_IdCategoria INT FOREIGN KEY REFERENCES Categoria(twmp_IdCategoria),
	twmp_StatusCompra BIT DEFAULT(0) NOT NULL
);

CREATE TABLE Interesse (
	twmp_IdInteresse INT IDENTITY PRIMARY KEY NOT NULL,
	twmp_IdUsuario INT FOREIGN KEY REFERENCES Usuario(twmp_IdUsuario),
	twmp_IdProduto INT FOREIGN KEY REFERENCES Produto(twmp_IdProduto),
	twmp_InteresseCompra BIT DEFAULT(1) NOT NULL,
	twmp_StatusCompra BIT DEFAULT(0) NOT NULL
);

CREATE TABLE ImgProduto (
	twmp_IdImgProduto INT IDENTITY PRIMARY KEY NOT NULL,
	Twmp_Nome VARCHAR(50),
	twmp_CaminhoImg VARCHAR(500),
	twmp_IdProduto INT FOREIGN KEY REFERENCES Produto(twmp_IdProduto)
);

INSERT INTO Categoria (twmp_CategoriaProduto)
VALUES ('Notebook'),
		('Smartphone'),
		('Monitor'),
		('Gabinete'),
		('Mouses'),
		('Teclados'),
		('Baterias'),
		('Cabos Energia'),
		('Modem'),
		('Outros');

INSERT INTO Permissao (twmp_TipoUsuario)
VALUES	('ADM'),
		('Comum');

INSERT INTO Usuario (twmp_Nome,twmp_Email,Twmp_Senha,twmp_IdPermissao)
VALUES		('Vicent','vicent_vivi@gmail.com','12345678',2),
			('Carlos','carlos.eduardo@live.com','12345678',1),
			('Roberto','r.berto@bol.com','12345678',2),
			('Mariana','mariana.mari@hotmail.com','12345678',2),
			('Gabriel Machado','gabriel.teixeira@hotmail.com','12345678',2),
			('Ana Paula Gomes','anapaula.machado@hotmail.com','12345678',2),
			('Helena Machado','helena.teixeira@gmail.com','12345678',2),
			('Mauro Amaral','mauro.teixeira@icloud.com','12345678',2),
			('Matheus Ducati','matheus.ducati@hotmail.com','12345678',2),
			('Gabriela Amaral','gabriela.ducati@live.com','12345678',2);

INSERT INTO Produto (twmp_Nome,twmp_Descricao,twmp_Preco,twmp_IdCategoria)
VALUES		('Dell Inspiron','Notebook com poucos arranhões',1500,1),
			('Moto G5s','Celular em perfeito estado de conservação',300,2),
			('Moto G5s','Celular em perfeito estado de conservação',300,2),
			('Mouse Dell','mouse Dell WM126',20,3),
			('Monitor Samsung','Monitor 23 poucos detalhes de uso',100,4),
			('Monitor Samsung','Monitor 23 poucos detalhes de uso',100,4),
			('Cabo Energia','Cabo de Energia para notebook Dell',15,8),
			('Modem TP-LINK','Modem roteador TP-LINK 500',20,9),
			('Xiaomi Mi A3','Celular Xiaomi com a tela trincada',300,2),
			('Macbook','Macbook 8GB ',1.700,1),
			('Moto G7s','Celular em perfeito estado de conservação',300,2);

INSERT INTO Interesse (twmp_IdUsuario, twmp_IdProduto)
VALUES
(1,2),
(2,1),
(2,2);

SELECT * FROM Interesse INNER JOIN Usuario ON Interesse.twmp_IdUsuario = Usuario.twmp_IdUsuario
SELECT * FROM Categoria
SELECT * FROM Interesse
SELECT * FROM Produto
SELECT * FROM Permissao
SELECT * FROM ImgProduto

/*DROP DATABASE TWMarketplace;*/