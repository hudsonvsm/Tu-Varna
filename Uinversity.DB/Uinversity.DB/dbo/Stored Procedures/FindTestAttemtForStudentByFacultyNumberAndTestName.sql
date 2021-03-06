﻿-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[FindTestAttemtForStudentByFacultyNumberAndTestName] 
	@FacultyNumber nvarchar(50),
	@TestName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Date], [Subject], Test, Question, Answer,
		IsCorrect, TestSemester, Teacher, SubjectClass,
		Student, Email, FacultyNumber, StudentClass
	FROM dbo.TestAtmptData_View as t
	WHERE t.FacultyNumber = @FacultyNumber AND t.Test = @TestName
END
