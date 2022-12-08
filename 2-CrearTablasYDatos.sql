USE [TiendaVirtual]
GO
ALTER TABLE [dbo].[Usuarios] DROP CONSTRAINT [FK_Usuarios_Roles]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 08/12/2022 15:43:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuarios]') AND type in (N'U'))
DROP TABLE [dbo].[Usuarios]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 08/12/2022 15:43:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type in (N'U'))
DROP TABLE [dbo].[Roles]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 08/12/2022 15:43:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Productos]') AND type in (N'U'))
DROP TABLE [dbo].[Productos]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 08/12/2022 15:43:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Stock] [int] NOT NULL,
	[Precio] [decimal](10, 2) NOT NULL,
	[Descripcion] [varchar](100) NULL,
	[EsActivo] [bit] NOT NULL,
	[ImagenUrl] [varchar](500) NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 08/12/2022 15:43:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[Rol] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 08/12/2022 15:43:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Documento] [varchar](15) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Clave] [varchar](11) NOT NULL,
	[IdRol] [int] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 
GO
INSERT [dbo].[Productos] ([IdProducto], [Nombre], [Stock], [Precio], [Descripcion], [EsActivo], [ImagenUrl]) VALUES (1, N'Iphone X', 5, CAST(1500000.00 AS Decimal(10, 2)), N'Iphone X 64 GB', 1, N'https://localhost:7028/imagenes/iphone-x.png')
GO
INSERT [dbo].[Productos] ([IdProducto], [Nombre], [Stock], [Precio], [Descripcion], [EsActivo], [ImagenUrl]) VALUES (2, N'Iphone 12', 10, CAST(2800000.00 AS Decimal(10, 2)), N'Iphone 12 128 GB', 1, N'https://localhost:7028/imagenes/iphone12.jpg')
GO
INSERT [dbo].[Productos] ([IdProducto], [Nombre], [Stock], [Precio], [Descripcion], [EsActivo], [ImagenUrl]) VALUES (3, N'Galaxy S22 Ultra', 5, CAST(5000000.00 AS Decimal(10, 2)), N'Samsung Galaxy S22 Ultra', 1, N'https://localhost:7028/imagenes/SamsungGalaxyS22Ultra.webp')
GO
INSERT [dbo].[Productos] ([IdProducto], [Nombre], [Stock], [Precio], [Descripcion], [EsActivo], [ImagenUrl]) VALUES (4, N'Xiaomi 12 PRO', 10, CAST(1500000.00 AS Decimal(10, 2)), N'Nuevo Xiomi PRO 12 ', 1, N'https://localhost:7028/imagenes/celular-xiaomi-12-pro-12gb-ram-256gb-azul.webp')
GO
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 
GO
INSERT [dbo].[Roles] ([IdRol], [Rol]) VALUES (1, N'Administrador')
GO
INSERT [dbo].[Roles] ([IdRol], [Rol]) VALUES (2, N'Cliente')
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 
GO
INSERT [dbo].[Usuarios] ([IdUsuario], [Documento], [Nombre], [Apellido], [Email], [Clave], [IdRol]) VALUES (1, N'123', N'Sara', N'Foronda', N'sara@gmail.com', N'1234', 1)
GO
INSERT [dbo].[Usuarios] ([IdUsuario], [Documento], [Nombre], [Apellido], [Email], [Clave], [IdRol]) VALUES (2, N'457', N'Pepito', N'Perez', N'pepito@gmail.com', N'1234', 2)
GO
INSERT [dbo].[Usuarios] ([IdUsuario], [Documento], [Nombre], [Apellido], [Email], [Clave], [IdRol]) VALUES (3, N'', N'Test', N'Test', N'teste@tests.com', N'1234', 2)
GO
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Roles] FOREIGN KEY([IdRol])
REFERENCES [dbo].[Roles] ([IdRol])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Roles]
GO
