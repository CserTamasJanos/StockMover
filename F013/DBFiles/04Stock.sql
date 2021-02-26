USE [FictiveCompany]
GO

/****** Object:  Table [dbo].[Stock]    Script Date: 2019. 10. 04. 9:38:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Stock](
	[StockCreationID] [int] IDENTITY(1,1) NOT NULL,
	[StoreHouseID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[StoredProductAmount] [int] NOT NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[StockCreationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [StoreHouseID] FOREIGN KEY([StoreHouseID])
REFERENCES [dbo].[StoreHouse] ([StoreHouseID])
GO

ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [StoreHouseID]
GO

