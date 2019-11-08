CREATE DATABASE TWMarketplace;

USE TWMarketplace;


CREATE TABLE Categoria (
	id_categoria INT IDENTITY PRIMARY KEY NOT NULL,
	categoria_Produto VARCHAR(50)
);

CREATE TABLE Permissao(
	id_permissao INT IDENTITY PRIMARY KEY NOT NULL,
	tipo_Usuario VARCHAR (50)
);

CREATE TABLE Situacao(
	id_Situacao INT IDENTITY PRIMARY KEY NOT NULL,
	
);

CREATE TABLE Usuario (
	id_usuario INT IDENTITY PRIMARY KEY NOT NULL,
	nome VARCHAR(50),
	email VARCHAR(50) UNIQUE,
	senha VARCHAR(10),
	id_permissao INT FOREIGN KEY REFERENCES Permissao(id_permissao)
);

CREATE TABLE Produtos (
	id_produto INT IDENTITY PRIMARY KEY NOT NULL,
	nome VARCHAR(50),
	descricao VARCHAR(250),
	preco MONEY,
	id_categoria INT FOREIGN KEY REFERENCES Categoria(id_categoria),
	status_Compra BIT DEFAULT(0) NOT NULL
);

CREATE TABLE Interesse (
	id_interesse INT IDENTITY PRIMARY KEY NOT NULL,
	id_usuario INT FOREIGN KEY REFERENCES Usuario(id_usuario),
	id_produto INT FOREIGN KEY REFERENCES Produtos(id_produto),
	status_Compra BIT DEFAULT(0) NOT NULL
);

CREATE TABLE ImgProduto (
	id_imgproduto INT IDENTITY PRIMARY KEY NOT NULL,
	nome VARCHAR(50),
	caminho_img VARCHAR(500) NOT NULL,
	id_produto INT FOREIGN KEY REFERENCES Produtos(id_produto)
);

INSERT INTO Categoria (categoria_Produto)
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

INSERT INTO Permissao (tipo_Usuario)
VALUES	('ADM'),
		('Comum');

INSERT INTO Usuario (nome,email,senha,id_permissao)
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

INSERT INTO Produtos (nome,descricao,preco,id_categoria)
VALUES		('Dell Inspiron','Notebook com poucos arranhões',1500,1),
			('Moto G5s','Celular em perfeito estado de conservação',300,2),
			('Moto G5s','Celular em perfeito estado de conservação',300,2),
			('Mouse Dell','mouse Dell WM126',20,3),
			('Monitor Samsung','Monitor 23 poucos detalhes de uso',100,4),
			('Monitor Samsung','Monitor 23 poucos detalhes de uso',100,4),
			('Cabo Energia','Cabo de Energia para notebook Dell',15,8),
			('Modem TP-LINK','Modem roteador TP-LINK 500',20,9),
			('Xiaomi Mi A3','Celular Xiaomi com a tela trincada',300,2),
			('Macbook','Macbook 8GB ',1.700,1);

INSERT INTO Interesse (id_usuario, id_produto)
VALUES
(1,2),
(2,1),
(2,2);

SELECT * FROM Interesse INNER JOIN Usuario ON Interesse.id_usuario = Usuario.id_usuario
SELECT * FROM Categoria
SELECT * FROM Interesse
SELECT * FROM Produtos
SELECT * FROM Permissao
SELECT * FROM ImgProduto

/*DROP DATABASE TWMarketplace;*/
			
INSERT INTO Produtos (nome,descricao,preco,id_categoria)
VALUES 
('Moto G7s','Celular em perfeito estado de conservação',300,2);