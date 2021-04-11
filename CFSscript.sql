USE [master]
GO
/****** Object:  Database [CFS]    Script Date: 4/12/2021 4:41:35 AM ******/
CREATE DATABASE [CFS]

GO
ALTER DATABASE [CFS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CFS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CFS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CFS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CFS] SET ARITHABORT OFF 
GO
ALTER DATABASE [CFS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CFS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CFS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CFS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CFS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CFS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CFS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CFS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CFS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CFS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CFS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CFS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CFS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CFS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CFS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CFS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CFS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CFS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CFS] SET  MULTI_USER 
GO
ALTER DATABASE [CFS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CFS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CFS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CFS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CFS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CFS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CFS] SET QUERY_STORE = OFF
GO
USE [CFS]
GO
/****** Object:  Table [dbo].[Agencies]    Script Date: 4/12/2021 4:41:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agencies](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Agency] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 4/12/2021 4:41:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[Id] [uniqueidentifier] NOT NULL,
	[EventNumber] [nvarchar](50) NOT NULL,
	[EventTypeId] [uniqueidentifier] NOT NULL,
	[EventTime] [datetime] NOT NULL,
	[DispatchTime] [datetime] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[ResponderId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventTypes]    Script Date: 4/12/2021 4:41:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventTypes](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_EventType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Responders]    Script Date: 4/12/2021 4:41:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Responders](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[AgencyId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Responders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/12/2021 4:41:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[AgencyId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Event_EventType] FOREIGN KEY([EventTypeId])
REFERENCES [dbo].[EventTypes] ([Id])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Event_EventType]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_Responders] FOREIGN KEY([ResponderId])
REFERENCES [dbo].[Responders] ([Id])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_Responders]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_Users]
GO
ALTER TABLE [dbo].[Responders]  WITH CHECK ADD  CONSTRAINT [FK_Responders_Agencies] FOREIGN KEY([AgencyId])
REFERENCES [dbo].[Agencies] ([Id])
GO
ALTER TABLE [dbo].[Responders] CHECK CONSTRAINT [FK_Responders_Agencies]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_User_Agency] FOREIGN KEY([AgencyId])
REFERENCES [dbo].[Agencies] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_User_Agency]
GO
USE [master]
GO
ALTER DATABASE [CFS] SET  READ_WRITE 
GO
