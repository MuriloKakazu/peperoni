ALTER TABLE [dbo].[Beverage]
	ADD CONSTRAINT [BeverageOrderConstraint]
	FOREIGN KEY (OrderId)
	REFERENCES [Order] (Id)
