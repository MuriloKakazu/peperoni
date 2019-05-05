ALTER TABLE [dbo].[Pizza]
	ADD CONSTRAINT [PizzaOrderConstraint]
	FOREIGN KEY (OrderId)
	REFERENCES [Order] (Id)
