USE [AttendanceSystemDB]
GO
/****** Object:  Table [dbo].[Attandence]    Script Date: 03/Jan/2017 2:51:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attandence](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeId] [int] NULL,
	[DateOfAttandence] [date] NULL,
	[CheckInTime] [time](7) NULL,
	[CheckOutTime] [time](7) NULL,
	[Status] [bit] NULL,
	[CheckOutStatus] [bit] NULL,
 CONSTRAINT [PK_Attandence] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeInfo]    Script Date: 03/Jan/2017 2:51:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmployeeInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Mobile] [varchar](50) NULL,
	[DateOfBirth] [date] NULL,
	[Designation] [nvarchar](50) NULL,
	[Status] [bit] NULL,
	[Photo] [image] NULL,
	[CreatedDate] [datetime2](7) NULL CONSTRAINT [DF__EmployeeI__Creat__1273C1CD]  DEFAULT (getdate()),
 CONSTRAINT [PK_EmployeeInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 03/Jan/2017 2:51:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] NOT NULL,
	[EmployeeId] [int] NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[CreatedDate] [date] NULL,
	[UserRoll] [varchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Attandence]  WITH CHECK ADD  CONSTRAINT [FK_Attandence_EmployeeInfo] FOREIGN KEY([EmployeId])
REFERENCES [dbo].[EmployeeInfo] ([Id])
GO
ALTER TABLE [dbo].[Attandence] CHECK CONSTRAINT [FK_Attandence_EmployeeInfo]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_EmployeeInfo] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[EmployeeInfo] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_EmployeeInfo]
GO
