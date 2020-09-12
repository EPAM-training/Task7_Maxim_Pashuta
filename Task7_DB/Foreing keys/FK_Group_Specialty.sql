ALTER TABLE [dbo].[Group]  
WITH CHECK ADD  CONSTRAINT [FK_Group_Specialty] FOREIGN KEY([SpecialtyID])
REFERENCES [dbo].[Specialty] ([ID])
ON DELETE SET NULL