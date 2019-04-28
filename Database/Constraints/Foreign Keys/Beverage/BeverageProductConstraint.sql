ALTER TABLE [dbo].[Beverage]
	ADD CONSTRAINT [BeverageProductConstraint]
	FOREIGN KEY (ProductId)
	REFERENCES [Product] (Id)
