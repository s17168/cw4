USE [s17168]
GO
ALTER TABLE [dbo].[Student] DROP CONSTRAINT [Student_Enrollment]
GO
ALTER TABLE [dbo].[Enrollment] DROP CONSTRAINT [Enrollment_Studies]
GO
/****** Object:  Table [dbo].[Studies]    Script Date: 03.04.2020 18:16:12 ******/
DROP TABLE [dbo].[Studies]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 03.04.2020 18:16:12 ******/
DROP TABLE [dbo].[Student]
GO
/****** Object:  Table [dbo].[Enrollment]    Script Date: 03.04.2020 18:16:12 ******/
DROP TABLE [dbo].[Enrollment]
GO
