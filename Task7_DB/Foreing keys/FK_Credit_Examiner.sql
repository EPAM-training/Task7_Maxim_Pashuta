ALTER TABLE [dbo].[Credit]  
WITH CHECK ADD  CONSTRAINT [FK_Credit_Examiner] FOREIGN KEY([ExaminerID])
REFERENCES [dbo].[Examiner] ([ID])
ON DELETE SET NULL