ALTER TABLE [dbo].[Pizza]
	ADD CONSTRAINT [PizzaBorderConstraint]
	FOREIGN KEY (BorderId)
	REFERENCES [Product] (Id)
