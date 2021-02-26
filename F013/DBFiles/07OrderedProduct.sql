USE [FictiveCompany]
GO

/****** Object:  Table [dbo].[OrderedProduct]    Script Date: 2019. 08. 20. 11:49:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OrderedProduct](
	[OrderedProductID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerOrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[OrderedAmount] [int] NOT NULL,
	[UnitPrice] [int] NOT NULL,
 CONSTRAINT [PK_OrderedProduct] PRIMARY KEY CLUSTERED 
(
	[OrderedProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OrderedProduct]  WITH CHECK ADD  CONSTRAINT [FK_OrderedProduct_CustomerOrder] FOREIGN KEY([CustomerOrderID])
REFERENCES [dbo].[CustomerOrder] ([CustomerOrderID])
GO

ALTER TABLE [dbo].[OrderedProduct] CHECK CONSTRAINT [FK_OrderedProduct_CustomerOrder]
GO

