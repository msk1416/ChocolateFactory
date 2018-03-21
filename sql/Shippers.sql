USE [ChocolateCo.]
GO

/****** Object:  Table [dbo].[Shippers]    Script Date: 21/03/2018 13:44:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Shippers](
	[ShipperID] [int] NOT NULL,
	[Name] [nchar](10) NOT NULL,
	[City] [nchar](10) NULL,
	[CostPerTon] [int] NOT NULL,
 CONSTRAINT [PK_Shippers] PRIMARY KEY CLUSTERED 
(
	[ShipperID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


