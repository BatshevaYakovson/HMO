USE [HMO]
GO

/****** Object:  Table [dbo].[Disease]    Script Date: 5/11/2023 5:16:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Disease](
	[EmployeeId] [bigint] NOT NULL,
	[PositiveResult] [date] NULL,
	[Recovery] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Employee]    Script Date: 5/11/2023 5:16:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employee](
	[EmployeeId] [bigint] NOT NULL,
	[FullName] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[BornDate] [date] NULL,
	[Phone] [varchar](10) NULL,
	[CellPhone] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[EmplVaccination]    Script Date: 5/11/2023 5:16:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EmplVaccination](
	[EmplVaccinationId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [bigint] NOT NULL,
	[VaccinationId] [int] NOT NULL,
	[VaccinationNum] [int] NULL,
	[Date] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmplVaccinationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Vaccination]    Script Date: 5/11/2023 5:16:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Vaccination](
	[VaccinationId] [int] IDENTITY(1,1) NOT NULL,
	[Manufacturer] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[VaccinationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Disease]  WITH CHECK ADD  CONSTRAINT [FK_Disease_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO

ALTER TABLE [dbo].[Disease] CHECK CONSTRAINT [FK_Disease_Employee]
GO

ALTER TABLE [dbo].[EmplVaccination]  WITH CHECK ADD  CONSTRAINT [FK_EmplVaccination_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO

ALTER TABLE [dbo].[EmplVaccination] CHECK CONSTRAINT [FK_EmplVaccination_Employee]
GO

ALTER TABLE [dbo].[EmplVaccination]  WITH CHECK ADD  CONSTRAINT [FK_EmplVaccination_Vaccination] FOREIGN KEY([VaccinationId])
REFERENCES [dbo].[Vaccination] ([VaccinationId])
GO

ALTER TABLE [dbo].[EmplVaccination] CHECK CONSTRAINT [FK_EmplVaccination_Vaccination]
GO


