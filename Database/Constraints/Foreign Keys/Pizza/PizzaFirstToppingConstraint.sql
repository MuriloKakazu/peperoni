ALTER TABLE [dbo].[Pizza]
	ADD CONSTRAINT [PizzaFirstToppingConstraint]
	FOREIGN KEY (FirstToppingId)
	REFERENCES [Product] (Id)
