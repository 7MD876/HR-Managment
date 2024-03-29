USE [master]
GO
/****** Object:  Database [teat2]    Script Date: 1/4/2024 1:55:10 PM ******/
CREATE DATABASE [teat2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'teat2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\teat2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'teat2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\teat2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [teat2] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [teat2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [teat2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [teat2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [teat2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [teat2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [teat2] SET ARITHABORT OFF 
GO
ALTER DATABASE [teat2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [teat2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [teat2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [teat2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [teat2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [teat2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [teat2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [teat2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [teat2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [teat2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [teat2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [teat2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [teat2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [teat2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [teat2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [teat2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [teat2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [teat2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [teat2] SET  MULTI_USER 
GO
ALTER DATABASE [teat2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [teat2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [teat2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [teat2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [teat2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [teat2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [teat2] SET QUERY_STORE = ON
GO
ALTER DATABASE [teat2] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [teat2]
GO
/****** Object:  User [sau]    Script Date: 1/4/2024 1:55:10 PM ******/
CREATE USER [sau] FOR LOGIN [sau] WITH DEFAULT_SCHEMA=[sau]
GO
/****** Object:  Schema [sau]    Script Date: 1/4/2024 1:55:10 PM ******/
CREATE SCHEMA [sau]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/4/2024 1:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetNavigationMenu]    Script Date: 1/4/2024 1:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetNavigationMenu](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[ParentMenuId] [uniqueidentifier] NULL,
	[Area] [nvarchar](max) NULL,
	[ControllerName] [nvarchar](max) NULL,
	[ActionName] [nvarchar](max) NULL,
	[IsExternal] [bit] NOT NULL,
	[ExternalUrl] [nvarchar](max) NULL,
	[DisplayOrder] [int] NOT NULL,
	[Visible] [bit] NOT NULL,
 CONSTRAINT [PK_AspNetNavigationMenu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 1/4/2024 1:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleMenuPermission]    Script Date: 1/4/2024 1:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleMenuPermission](
	[RoleId] [nvarchar](450) NOT NULL,
	[NavigationMenuId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AspNetRoleMenuPermission] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[NavigationMenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 1/4/2024 1:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 1/4/2024 1:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 1/4/2024 1:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 1/4/2024 1:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 1/4/2024 1:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 1/4/2024 1:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 1/4/2024 1:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseID] [int] IDENTITY(1,1) NOT NULL,
	[CourseNumber] [int] NOT NULL,
	[CourseName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[E_Courses]    Script Date: 1/4/2024 1:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_Courses](
	[IDEmployeesCourses] [int] IDENTITY(1,1) NOT NULL,
	[IDEmployees] [int] NOT NULL,
	[CourseID] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[rating] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_E_Courses] PRIMARY KEY CLUSTERED 
(
	[IDEmployeesCourses] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[E_Jobs]    Script Date: 1/4/2024 1:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_Jobs](
	[E_JobsID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[JobID] [int] NOT NULL,
 CONSTRAINT [PK_E_Jobs] PRIMARY KEY CLUSTERED 
(
	[E_JobsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[E_Medels]    Script Date: 1/4/2024 1:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_Medels](
	[IDE_Medals] [int] IDENTITY(1,1) NOT NULL,
	[MedalsID] [int] NOT NULL,
	[DateMedals] [date] NOT NULL,
	[IDEmployees] [int] NOT NULL,
 CONSTRAINT [PK_Medals] PRIMARY KEY CLUSTERED 
(
	[IDE_Medals] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[E_Transfer]    Script Date: 1/4/2024 1:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_Transfer](
	[IdTransfer] [int] IDENTITY(1,1) NOT NULL,
	[TransferID] [int] NOT NULL,
	[IdEmployees] [int] NOT NULL,
	[TransferDate] [date] NOT NULL,
 CONSTRAINT [PK_Transfer] PRIMARY KEY CLUSTERED 
(
	[IdTransfer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employees]    Script Date: 1/4/2024 1:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employees](
	[IdEmployees] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[IDENTITYNUMBER] [int] NOT NULL,
	[EMPLOYEENUMBER] [int] NOT NULL,
	[Gender] [int] NOT NULL,
	[JopType] [int] NOT NULL,
	[RankID] [int] NOT NULL,
 CONSTRAINT [PK_employees] PRIMARY KEY CLUSTERED 
(
	[IdEmployees] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jops]    Script Date: 1/4/2024 1:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jops](
	[IDJops] [int] IDENTITY(1,1) NOT NULL,
	[JopName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Jops] PRIMARY KEY CLUSTERED 
(
	[IDJops] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medels]    Script Date: 1/4/2024 1:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medels](
	[IDMedels] [int] IDENTITY(1,1) NOT NULL,
	[MedelsName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Medels] PRIMARY KEY CLUSTERED 
(
	[IDMedels] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rank]    Script Date: 1/4/2024 1:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rank](
	[IDRank] [int] IDENTITY(1,1) NOT NULL,
	[Rankname] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Rank] PRIMARY KEY CLUSTERED 
(
	[IDRank] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tranfer]    Script Date: 1/4/2024 1:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tranfer](
	[transferID] [int] IDENTITY(1,1) NOT NULL,
	[TransferName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Tranfer] PRIMARY KEY CLUSTERED 
(
	[transferID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220415211921_initial', N'7.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230919195209_InitialMigration', N'7.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240102074022_first', N'7.0.11')
GO
INSERT [dbo].[AspNetNavigationMenu] ([Id], [Name], [ParentMenuId], [Area], [ControllerName], [ActionName], [IsExternal], [ExternalUrl], [DisplayOrder], [Visible]) VALUES (N'1064fb17-04a8-4df3-94c1-057ab82dd22c', N'الموظفين', NULL, NULL, NULL, NULL, 0, NULL, 1, 1)
INSERT [dbo].[AspNetNavigationMenu] ([Id], [Name], [ParentMenuId], [Area], [ControllerName], [ActionName], [IsExternal], [ExternalUrl], [DisplayOrder], [Visible]) VALUES (N'13e2f21a-4283-4ff8-bb7a-096e7b89e0f0', N'Admin', NULL, NULL, N'', N'', 0, NULL, 1, 1)
INSERT [dbo].[AspNetNavigationMenu] ([Id], [Name], [ParentMenuId], [Area], [ControllerName], [ActionName], [IsExternal], [ExternalUrl], [DisplayOrder], [Visible]) VALUES (N'7cd0d373-c57d-4c70-aa8c-22791983fe1c', N'Users', N'13e2f21a-4283-4ff8-bb7a-096e7b89e0f0', NULL, N'Admin', N'Users', 0, NULL, 3, 1)
INSERT [dbo].[AspNetNavigationMenu] ([Id], [Name], [ParentMenuId], [Area], [ControllerName], [ActionName], [IsExternal], [ExternalUrl], [DisplayOrder], [Visible]) VALUES (N'3c1702c5-c34f-4468-b807-3a1d5545f734', N'Edit User', N'13e2f21a-4283-4ff8-bb7a-096e7b89e0f0', NULL, N'Admin', N'EditUser', 0, NULL, 3, 0)
INSERT [dbo].[AspNetNavigationMenu] ([Id], [Name], [ParentMenuId], [Area], [ControllerName], [ActionName], [IsExternal], [ExternalUrl], [DisplayOrder], [Visible]) VALUES (N'0f493d0d-a81e-49c9-b618-8adfb351f525', N'القوائم', NULL, NULL, N'AspNetNavigationMenus', N'Index', 0, NULL, 1, 1)
INSERT [dbo].[AspNetNavigationMenu] ([Id], [Name], [ParentMenuId], [Area], [ControllerName], [ActionName], [IsExternal], [ExternalUrl], [DisplayOrder], [Visible]) VALUES (N'94c22f11-6dd2-4b9c-95f7-9dd4ea1002e6', N'Edit Role Permission', N'13e2f21a-4283-4ff8-bb7a-096e7b89e0f0', NULL, N'Admin', N'EditRolePermission', 0, NULL, 3, 0)
INSERT [dbo].[AspNetNavigationMenu] ([Id], [Name], [ParentMenuId], [Area], [ControllerName], [ActionName], [IsExternal], [ExternalUrl], [DisplayOrder], [Visible]) VALUES (N'283264d6-0e5e-48fe-9d6e-b1599aa0892c', N'Roles', N'13e2f21a-4283-4ff8-bb7a-096e7b89e0f0', NULL, N'Admin', N'Roles', 0, NULL, 1, 1)
INSERT [dbo].[AspNetNavigationMenu] ([Id], [Name], [ParentMenuId], [Area], [ControllerName], [ActionName], [IsExternal], [ExternalUrl], [DisplayOrder], [Visible]) VALUES (N'f704bdfd-d3ea-4a6f-9463-da47ed3657ab', N'External Google Link', N'13e2f21a-4283-4ff8-bb7a-096e7b89e0f0', NULL, N'', N'', 1, N'https://www.google.com/', 2, 1)
INSERT [dbo].[AspNetNavigationMenu] ([Id], [Name], [ParentMenuId], [Area], [ControllerName], [ActionName], [IsExternal], [ExternalUrl], [DisplayOrder], [Visible]) VALUES (N'913bf559-db46-4072-bd01-f73f3c92e5d5', N'Create Role', N'13e2f21a-4283-4ff8-bb7a-096e7b89e0f0', NULL, N'Admin', N'CreateRole', 0, NULL, 3, 1)
GO
INSERT [dbo].[AspNetRoleMenuPermission] ([RoleId], [NavigationMenuId]) VALUES (N'f2958ed7-75f5-4530-bb67-0d2dd09377de', N'1064fb17-04a8-4df3-94c1-057ab82dd22c')
INSERT [dbo].[AspNetRoleMenuPermission] ([RoleId], [NavigationMenuId]) VALUES (N'13c442a2-18ee-408c-9ad5-d212e1f9b46a', N'13e2f21a-4283-4ff8-bb7a-096e7b89e0f0')
INSERT [dbo].[AspNetRoleMenuPermission] ([RoleId], [NavigationMenuId]) VALUES (N'f2958ed7-75f5-4530-bb67-0d2dd09377de', N'13e2f21a-4283-4ff8-bb7a-096e7b89e0f0')
INSERT [dbo].[AspNetRoleMenuPermission] ([RoleId], [NavigationMenuId]) VALUES (N'f2958ed7-75f5-4530-bb67-0d2dd09377de', N'7cd0d373-c57d-4c70-aa8c-22791983fe1c')
INSERT [dbo].[AspNetRoleMenuPermission] ([RoleId], [NavigationMenuId]) VALUES (N'f2958ed7-75f5-4530-bb67-0d2dd09377de', N'3c1702c5-c34f-4468-b807-3a1d5545f734')
INSERT [dbo].[AspNetRoleMenuPermission] ([RoleId], [NavigationMenuId]) VALUES (N'f2958ed7-75f5-4530-bb67-0d2dd09377de', N'0f493d0d-a81e-49c9-b618-8adfb351f525')
INSERT [dbo].[AspNetRoleMenuPermission] ([RoleId], [NavigationMenuId]) VALUES (N'f2958ed7-75f5-4530-bb67-0d2dd09377de', N'94c22f11-6dd2-4b9c-95f7-9dd4ea1002e6')
INSERT [dbo].[AspNetRoleMenuPermission] ([RoleId], [NavigationMenuId]) VALUES (N'13c442a2-18ee-408c-9ad5-d212e1f9b46a', N'283264d6-0e5e-48fe-9d6e-b1599aa0892c')
INSERT [dbo].[AspNetRoleMenuPermission] ([RoleId], [NavigationMenuId]) VALUES (N'f2958ed7-75f5-4530-bb67-0d2dd09377de', N'283264d6-0e5e-48fe-9d6e-b1599aa0892c')
INSERT [dbo].[AspNetRoleMenuPermission] ([RoleId], [NavigationMenuId]) VALUES (N'f2958ed7-75f5-4530-bb67-0d2dd09377de', N'f704bdfd-d3ea-4a6f-9463-da47ed3657ab')
INSERT [dbo].[AspNetRoleMenuPermission] ([RoleId], [NavigationMenuId]) VALUES (N'f2958ed7-75f5-4530-bb67-0d2dd09377de', N'913bf559-db46-4072-bd01-f73f3c92e5d5')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'13c442a2-18ee-408c-9ad5-d212e1f9b46a', N'Manager', N'MANAGER', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'f23edf79-8e5d-410a-a857-bf87b914c92d', N'Employee', N'EMPLOYEE', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'f2958ed7-75f5-4530-bb67-0d2dd09377de', N'Admin', N'ADMIN', NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6c5c0dcf-7544-4060-99d6-26832fa4f2c9', N'13c442a2-18ee-408c-9ad5-d212e1f9b46a')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2db59034-9f92-42fa-9156-482b02b2fb8b', N'f23edf79-8e5d-410a-a857-bf87b914c92d')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fca95180-6df6-40d2-b193-108832b9efb2', N'f2958ed7-75f5-4530-bb67-0d2dd09377de')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'2db59034-9f92-42fa-9156-482b02b2fb8b', N'employee@test.com', N'EMPLOYEE@TEST.COM', N'employee@test.com', N'EMPLOYEE@TEST.COM', 1, N'AQAAAAIAAYagAAAAECFGPSd3xADLBYUn5zXdXy0d72exhgKQ9CKlA1NXOXFMDMqb91Wq46+He68yWoHV3w==', N'NH3BQXAYLKDCG6R7QKUGBZON77YO5G7X', N'cfc7222f-6500-4baf-9926-72474e9b47d0', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'6c5c0dcf-7544-4060-99d6-26832fa4f2c9', N'manager@test.com', N'MANAGER@TEST.COM', N'manager@test.com', N'MANAGER@TEST.COM', 1, N'AQAAAAIAAYagAAAAECTxlPlSCDIGr3ghSTkO+RBj9PnFQnZ0mjfw0Nbx5QG8hWmoLluRq9HDlqPpJ8qOhQ==', N'POV5PAXN66IUBWN3LDFSKCK5QPLPZMKJ', N'37bfcdb6-61ef-4c5c-9c7b-e8d87f62cb48', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'fca95180-6df6-40d2-b193-108832b9efb2', N'admin@test.com', N'ADMIN@TEST.COM', N'admin@test.com', N'ADMIN@TEST.COM', 1, N'AQAAAAIAAYagAAAAEICtyI4o674e4lo3mgeG9CuW3i68dbdgvKHWe8qlUIlF77GUGhowBWys/UdHSovNGQ==', N'NTR75DERJHDP4V6BZNK6BLGNQJQ3FHXH', N'0af2bb0c-2685-470c-b9c4-8665f0161925', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[employees] ON 

INSERT [dbo].[employees] ([IdEmployees], [name], [IDENTITYNUMBER], [EMPLOYEENUMBER], [Gender], [JopType], [RankID]) VALUES (2, N'MO', 1096556699, 451201, 1, 1, 1)
INSERT [dbo].[employees] ([IdEmployees], [name], [IDENTITYNUMBER], [EMPLOYEENUMBER], [Gender], [JopType], [RankID]) VALUES (3, N'MOYA S', 1096556699, 451201, 1, 2, 1)
INSERT [dbo].[employees] ([IdEmployees], [name], [IDENTITYNUMBER], [EMPLOYEENUMBER], [Gender], [JopType], [RankID]) VALUES (4, N'MO', 1641044622, 102555, 2, 1, 1)
SET IDENTITY_INSERT [dbo].[employees] OFF
GO
SET IDENTITY_INSERT [dbo].[Jops] ON 

INSERT [dbo].[Jops] ([IDJops], [JopName]) VALUES (1, N'plumber')
INSERT [dbo].[Jops] ([IDJops], [JopName]) VALUES (2, N'tech')
INSERT [dbo].[Jops] ([IDJops], [JopName]) VALUES (3, N'يي')
SET IDENTITY_INSERT [dbo].[Jops] OFF
GO
SET IDENTITY_INSERT [dbo].[Rank] ON 

INSERT [dbo].[Rank] ([IDRank], [Rankname]) VALUES (1, N'الاول')
INSERT [dbo].[Rank] ([IDRank], [Rankname]) VALUES (2, N' الثاني')
SET IDENTITY_INSERT [dbo].[Rank] OFF
GO
/****** Object:  Index [IX_AspNetNavigationMenu_ParentMenuId]    Script Date: 1/4/2024 1:55:10 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetNavigationMenu_ParentMenuId] ON [dbo].[AspNetNavigationMenu]
(
	[ParentMenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 1/4/2024 1:55:10 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetRoleMenuPermission_NavigationMenuId]    Script Date: 1/4/2024 1:55:10 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleMenuPermission_NavigationMenuId] ON [dbo].[AspNetRoleMenuPermission]
(
	[NavigationMenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 1/4/2024 1:55:10 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 1/4/2024 1:55:10 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 1/4/2024 1:55:10 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 1/4/2024 1:55:10 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 1/4/2024 1:55:10 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 1/4/2024 1:55:10 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetNavigationMenu]  WITH CHECK ADD  CONSTRAINT [FK_AspNetNavigationMenu_AspNetNavigationMenu_ParentMenuId] FOREIGN KEY([ParentMenuId])
REFERENCES [dbo].[AspNetNavigationMenu] ([Id])
GO
ALTER TABLE [dbo].[AspNetNavigationMenu] CHECK CONSTRAINT [FK_AspNetNavigationMenu_AspNetNavigationMenu_ParentMenuId]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetRoleMenuPermission]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleMenuPermission_AspNetNavigationMenu_NavigationMenuId] FOREIGN KEY([NavigationMenuId])
REFERENCES [dbo].[AspNetNavigationMenu] ([Id])
GO
ALTER TABLE [dbo].[AspNetRoleMenuPermission] CHECK CONSTRAINT [FK_AspNetRoleMenuPermission_AspNetNavigationMenu_NavigationMenuId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[E_Courses]  WITH CHECK ADD  CONSTRAINT [FK_E_Courses_Course] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([CourseID])
GO
ALTER TABLE [dbo].[E_Courses] CHECK CONSTRAINT [FK_E_Courses_Course]
GO
ALTER TABLE [dbo].[E_Courses]  WITH CHECK ADD  CONSTRAINT [FK_E_Courses_employees] FOREIGN KEY([IDEmployees])
REFERENCES [dbo].[employees] ([IdEmployees])
GO
ALTER TABLE [dbo].[E_Courses] CHECK CONSTRAINT [FK_E_Courses_employees]
GO
ALTER TABLE [dbo].[E_Jobs]  WITH CHECK ADD  CONSTRAINT [FK_E_Jobs_employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[employees] ([IdEmployees])
GO
ALTER TABLE [dbo].[E_Jobs] CHECK CONSTRAINT [FK_E_Jobs_employees]
GO
ALTER TABLE [dbo].[E_Jobs]  WITH CHECK ADD  CONSTRAINT [FK_E_Jobs_Jops] FOREIGN KEY([JobID])
REFERENCES [dbo].[Jops] ([IDJops])
GO
ALTER TABLE [dbo].[E_Jobs] CHECK CONSTRAINT [FK_E_Jobs_Jops]
GO
ALTER TABLE [dbo].[E_Medels]  WITH CHECK ADD  CONSTRAINT [FK_E_Medels_Medels] FOREIGN KEY([MedalsID])
REFERENCES [dbo].[Medels] ([IDMedels])
GO
ALTER TABLE [dbo].[E_Medels] CHECK CONSTRAINT [FK_E_Medels_Medels]
GO
ALTER TABLE [dbo].[E_Medels]  WITH CHECK ADD  CONSTRAINT [FK_Medals_employees] FOREIGN KEY([IDEmployees])
REFERENCES [dbo].[employees] ([IdEmployees])
GO
ALTER TABLE [dbo].[E_Medels] CHECK CONSTRAINT [FK_Medals_employees]
GO
ALTER TABLE [dbo].[E_Transfer]  WITH CHECK ADD  CONSTRAINT [FK_E_Transfer_Tranfer] FOREIGN KEY([IdTransfer])
REFERENCES [dbo].[Tranfer] ([transferID])
GO
ALTER TABLE [dbo].[E_Transfer] CHECK CONSTRAINT [FK_E_Transfer_Tranfer]
GO
ALTER TABLE [dbo].[E_Transfer]  WITH CHECK ADD  CONSTRAINT [FK_Transfer_employees] FOREIGN KEY([IdEmployees])
REFERENCES [dbo].[employees] ([IdEmployees])
GO
ALTER TABLE [dbo].[E_Transfer] CHECK CONSTRAINT [FK_Transfer_employees]
GO
ALTER TABLE [dbo].[employees]  WITH CHECK ADD  CONSTRAINT [FK_employees_Jops] FOREIGN KEY([JopType])
REFERENCES [dbo].[Jops] ([IDJops])
GO
ALTER TABLE [dbo].[employees] CHECK CONSTRAINT [FK_employees_Jops]
GO
ALTER TABLE [dbo].[employees]  WITH CHECK ADD  CONSTRAINT [FK_employees_Rank] FOREIGN KEY([RankID])
REFERENCES [dbo].[Rank] ([IDRank])
GO
ALTER TABLE [dbo].[employees] CHECK CONSTRAINT [FK_employees_Rank]
GO
USE [master]
GO
ALTER DATABASE [teat2] SET  READ_WRITE 
GO
