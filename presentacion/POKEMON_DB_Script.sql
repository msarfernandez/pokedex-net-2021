use master
go
create database POKEDEX_DB
go
use POKEDEX_DB
go
USE POKEDEX_DB
GO

/****** Object:  Table [dbo].[ELEMENTOS]    Script Date: 4/15/2021 6:37:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ELEMENTOS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_ELEMENTOS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [POKEDEX_DB]
GO

/****** Object:  Table [dbo].[POKEMONS]    Script Date: 4/15/2021 6:37:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[POKEMONS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [int] NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](50) NULL,
	[UrlImagen] [varchar](300) NULL,
	[IdTipo] [int] NULL,
	[IdDebilidad] [int] NULL,
	[IdEvolucion] [int] NULL,
 CONSTRAINT [PK_POKEMONS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[POKEMONS]  WITH CHECK ADD  CONSTRAINT [FK_POKEMONS_ELEMENTOS] FOREIGN KEY([IdTipo])
REFERENCES [dbo].[ELEMENTOS] ([Id])
GO

ALTER TABLE [dbo].[POKEMONS] CHECK CONSTRAINT [FK_POKEMONS_ELEMENTOS]
GO

ALTER TABLE [dbo].[POKEMONS]  WITH CHECK ADD  CONSTRAINT [FK_POKEMONS_ELEMENTOS1] FOREIGN KEY([IdDebilidad])
REFERENCES [dbo].[ELEMENTOS] ([Id])
GO

ALTER TABLE [dbo].[POKEMONS] CHECK CONSTRAINT [FK_POKEMONS_ELEMENTOS1]
GO

ALTER TABLE [dbo].[POKEMONS]  WITH CHECK ADD  CONSTRAINT [FK_POKEMONS_POKEMONS] FOREIGN KEY([IdEvolucion])
REFERENCES [dbo].[POKEMONS] ([Id])
GO

ALTER TABLE [dbo].[POKEMONS] CHECK CONSTRAINT [FK_POKEMONS_POKEMONS]
GO

-- inserta pokemons
insert into POKEMONS values(1, 'Bulbasaur', 'Este Pokémon nace con una semilla en el lomo.', 'https://assets.pokemon.com/assets/cms2/img/pokedex/full/001.png', null, null, null)
insert into POKEMONS values(2, 'Ivysaur', 'Cuando le crece bastante el bulbo del lomo.', 'https://assets.pokemon.com/assets/cms2/img/pokedex/full/002.png', null, null, null)
insert into POKEMONS values(3, 'Venusaur', 'La planta florece cuando absorbe energía solar.', 'https://assets.pokemon.com/assets/cms2/img/pokedex/full/003.png', null, null, null)

go
-- inserta elementos 
insert into ELEMENTOS values ('Planta')
insert into ELEMENTOS values ('Fuego')
insert into ELEMENTOS values ('Agua')

go
-- actualiza tipo y debilidad a los pokemons
update pokemons set IdTipo = 1
update pokemons set IdDebilidad = 2

--  actualiza el id de evlucion, ver bien los ids
-- update pokemons set IdEvolucion = 7 where id = 6