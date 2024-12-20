USE [master]
GO
/****** Object:  Database [L3_Sistema3erP2024N]    Script Date: 11/12/2024 15:15:59 ******/
CREATE DATABASE [L3_Sistema3erP2024N]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'L3_Sistema3erP2024N', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\L3_Sistema3erP2024N.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'L3_Sistema3erP2024N_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\L3_Sistema3erP2024N_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [L3_Sistema3erP2024N] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [L3_Sistema3erP2024N].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [L3_Sistema3erP2024N] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [L3_Sistema3erP2024N] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [L3_Sistema3erP2024N] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [L3_Sistema3erP2024N] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [L3_Sistema3erP2024N] SET ARITHABORT OFF 
GO
ALTER DATABASE [L3_Sistema3erP2024N] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [L3_Sistema3erP2024N] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [L3_Sistema3erP2024N] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [L3_Sistema3erP2024N] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [L3_Sistema3erP2024N] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [L3_Sistema3erP2024N] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [L3_Sistema3erP2024N] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [L3_Sistema3erP2024N] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [L3_Sistema3erP2024N] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [L3_Sistema3erP2024N] SET  ENABLE_BROKER 
GO
ALTER DATABASE [L3_Sistema3erP2024N] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [L3_Sistema3erP2024N] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [L3_Sistema3erP2024N] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [L3_Sistema3erP2024N] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [L3_Sistema3erP2024N] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [L3_Sistema3erP2024N] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [L3_Sistema3erP2024N] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [L3_Sistema3erP2024N] SET RECOVERY FULL 
GO
ALTER DATABASE [L3_Sistema3erP2024N] SET  MULTI_USER 
GO
ALTER DATABASE [L3_Sistema3erP2024N] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [L3_Sistema3erP2024N] SET DB_CHAINING OFF 
GO
ALTER DATABASE [L3_Sistema3erP2024N] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [L3_Sistema3erP2024N] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [L3_Sistema3erP2024N] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [L3_Sistema3erP2024N] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'L3_Sistema3erP2024N', N'ON'
GO
ALTER DATABASE [L3_Sistema3erP2024N] SET QUERY_STORE = ON
GO
ALTER DATABASE [L3_Sistema3erP2024N] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [L3_Sistema3erP2024N]
GO
/****** Object:  Table [dbo].[articulo]    Script Date: 11/12/2024 15:15:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[articulo](
	[idarticulo] [int] IDENTITY(1,1) NOT NULL,
	[idcategoria] [int] NOT NULL,
	[codigo] [varchar](50) NULL,
	[nombre] [varchar](100) NOT NULL,
	[precio_venta] [decimal](11, 2) NOT NULL,
	[stock] [int] NOT NULL,
	[descripcion] [varchar](255) NULL,
	[imagen] [varchar](20) NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idarticulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[precio_venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categoria]    Script Date: 11/12/2024 15:15:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categoria](
	[idcategoria] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](100) NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idcategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalle_ingreso]    Script Date: 11/12/2024 15:15:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_ingreso](
	[iddetalle_ingreso] [int] IDENTITY(1,1) NOT NULL,
	[idingreso] [int] NOT NULL,
	[idarticulo] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[precio] [decimal](11, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[iddetalle_ingreso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalle_venta]    Script Date: 11/12/2024 15:15:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_venta](
	[iddetalle_venta] [int] IDENTITY(1,1) NOT NULL,
	[idventa] [int] NOT NULL,
	[idarticulo] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[precio] [decimal](11, 2) NOT NULL,
	[decuento] [decimal](11, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[iddetalle_venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ingreso]    Script Date: 11/12/2024 15:15:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ingreso](
	[idingreso] [int] IDENTITY(1,1) NOT NULL,
	[idproveedor] [int] NOT NULL,
	[idusuario] [int] NOT NULL,
	[Tipo_comprovante] [varchar](20) NOT NULL,
	[Serie_comprovante] [varchar](7) NULL,
	[num_comprovante] [varchar](10) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[impuesto] [decimal](4, 2) NOT NULL,
	[total] [decimal](11, 2) NOT NULL,
	[estdo] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idingreso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[persona]    Script Date: 11/12/2024 15:15:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[persona](
	[idpersona] [int] IDENTITY(1,1) NOT NULL,
	[tipo_persona] [varchar](20) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[Tipo_documento] [varchar](20) NULL,
	[stock] [int] NOT NULL,
	[direccion] [varchar](70) NULL,
	[telefono] [varchar](20) NULL,
	[email] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[idpersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rol]    Script Date: 11/12/2024 15:15:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rol](
	[idrol] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](30) NOT NULL,
	[descripcion] [varchar](255) NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idrol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 11/12/2024 15:15:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[idusuario] [int] IDENTITY(1,1) NOT NULL,
	[idrol] [int] NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[Tipo_documento] [varchar](20) NULL,
	[num_documento] [varchar](20) NULL,
	[direccion] [varchar](70) NULL,
	[telefono] [varchar](20) NULL,
	[email] [varchar](50) NOT NULL,
	[clave] [varbinary](max) NOT NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idusuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[venta]    Script Date: 11/12/2024 15:15:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venta](
	[idventa] [int] IDENTITY(1,1) NOT NULL,
	[idcliente] [int] NOT NULL,
	[idusuario] [int] NOT NULL,
	[Tipo_comprovante] [varchar](20) NOT NULL,
	[Serie_comprovante] [varchar](7) NULL,
	[num_comprovante] [varchar](10) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[impuesto] [decimal](4, 2) NOT NULL,
	[total] [decimal](11, 2) NOT NULL,
	[estdo] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idventa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[articulo] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[categoria] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[rol] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[usuario] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[articulo]  WITH CHECK ADD FOREIGN KEY([idcategoria])
REFERENCES [dbo].[categoria] ([idcategoria])
GO
ALTER TABLE [dbo].[detalle_ingreso]  WITH CHECK ADD FOREIGN KEY([idarticulo])
REFERENCES [dbo].[articulo] ([idarticulo])
GO
ALTER TABLE [dbo].[detalle_ingreso]  WITH CHECK ADD FOREIGN KEY([idingreso])
REFERENCES [dbo].[ingreso] ([idingreso])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[detalle_venta]  WITH CHECK ADD FOREIGN KEY([idarticulo])
REFERENCES [dbo].[articulo] ([idarticulo])
GO
ALTER TABLE [dbo].[detalle_venta]  WITH CHECK ADD FOREIGN KEY([idventa])
REFERENCES [dbo].[venta] ([idventa])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ingreso]  WITH CHECK ADD FOREIGN KEY([idproveedor])
REFERENCES [dbo].[persona] ([idpersona])
GO
ALTER TABLE [dbo].[ingreso]  WITH CHECK ADD FOREIGN KEY([idusuario])
REFERENCES [dbo].[usuario] ([idusuario])
GO
ALTER TABLE [dbo].[usuario]  WITH CHECK ADD FOREIGN KEY([idrol])
REFERENCES [dbo].[rol] ([idrol])
GO
ALTER TABLE [dbo].[venta]  WITH CHECK ADD FOREIGN KEY([idcliente])
REFERENCES [dbo].[persona] ([idpersona])
GO
ALTER TABLE [dbo].[venta]  WITH CHECK ADD FOREIGN KEY([idusuario])
REFERENCES [dbo].[usuario] ([idusuario])
GO
/****** Object:  StoredProcedure [dbo].[categoria_activar]    Script Date: 11/12/2024 15:15:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[categoria_activar]
@idcategoria int
as
update categoria set estado=1
where idcategoria=@idcategoria
GO
/****** Object:  StoredProcedure [dbo].[categoria_actualizar]    Script Date: 11/12/2024 15:15:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[categoria_actualizar]
@idcategoria int,
@nombre varchar(50),
@descripcion varchar(100)
as
update categoria set nombre=@nombre, descripcion=@descripcion
where idcategoria=@idcategoria
GO
/****** Object:  StoredProcedure [dbo].[categoria_buscar]    Script Date: 11/12/2024 15:15:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[categoria_buscar]
@valor varchar(50)
as
select idcategoria as ID, nombre as Nombre, descripcion as Descripcion,
estado as Estado
from categoria
where nombre like '%' + @valor + '%' Or descripcion like '%' + @valor + '%'
Order by nombre asc
GO
/****** Object:  StoredProcedure [dbo].[categoria_desactivar]    Script Date: 11/12/2024 15:15:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[categoria_desactivar]
@idcategoria int
as
update categoria set estado=0
where idcategoria=@idcategoria
GO
/****** Object:  StoredProcedure [dbo].[categoria_eliminar]    Script Date: 11/12/2024 15:15:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[categoria_eliminar]
@idcategoria int
as
delete from categoria
where idcategoria=@idcategoria
GO
/****** Object:  StoredProcedure [dbo].[categoria_existe]    Script Date: 11/12/2024 15:15:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[categoria_existe]
@valor varchar(100),
@existe bit output
as
if exists (select nombre from categoria where nombre = ltrim(rtrim(@valor)))
begin
set @existe=1
end
else
begin
set @existe=0
end
GO
/****** Object:  StoredProcedure [dbo].[categoria_insertar]    Script Date: 11/12/2024 15:15:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[categoria_insertar]
@nombre varchar(50),
@descripcion varchar(100)
as
insert into categoria (nombre,descripcion) values (@nombre,@descripcion)
GO
/****** Object:  StoredProcedure [dbo].[categoria_Listar]    Script Date: 11/12/2024 15:15:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[categoria_Listar]
as
select idcategoria as ID, nombre as nombre,descripcion as descripcion,
estado as estado
from categoria
order by idcategoria desc
GO
USE [master]
GO
ALTER DATABASE [L3_Sistema3erP2024N] SET  READ_WRITE 
GO
