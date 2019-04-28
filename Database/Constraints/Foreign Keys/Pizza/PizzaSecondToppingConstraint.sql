ALTER TABLE [dbo].[Pizza]
	ADD CONSTRAINT [PizzaSecondToppingConstraint]
	FOREIGN KEY (SecondToppingId)
	REFERENCES [Product] (Id)
