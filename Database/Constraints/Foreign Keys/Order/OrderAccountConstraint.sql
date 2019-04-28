ALTER TABLE [dbo].[Order]
	ADD CONSTRAINT [OrderAccountConstraint]
	FOREIGN KEY (AccountId)
	REFERENCES [Account] (Id)
