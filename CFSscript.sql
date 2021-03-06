

CREATE TABLE [dbo].[Agencies](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Agency] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
))

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
))

CREATE TABLE [dbo].[EventTypes](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_EventType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
))

CREATE TABLE [dbo].[Responders](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[AgencyId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Responders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
))

CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[AgencyId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
))

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
