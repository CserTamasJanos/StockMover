USE [FictiveCompany]
GO

/****** Object:  Table [dbo].[StoreHouse]    Script Date: 2019. 10. 04. 9:37:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StoreHouse](
	[StoreHouseID] [int] IDENTITY(1,1) NOT NULL,
	[StoreHouseName] [varchar](50) NOT NULL,
	[StoreHouseAddress] [varchar](50) NOT NULL,
 CONSTRAINT [PK_StoreHouse] PRIMARY KEY CLUSTERED 
(
	[StoreHouseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

