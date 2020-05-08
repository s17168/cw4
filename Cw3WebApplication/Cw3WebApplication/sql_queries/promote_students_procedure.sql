DROP PROCEDURE IF EXISTS PromoteStudents -- ms sql procedure
GO

CREATE PROCEDURE PromoteStudents 
	@studyName varchar(100), 
	@existingSemester int
AS
BEGIN
	SET XACT_ABORT ON;
	BEGIN TRANSACTION

	-- spr czy w tabeli Studies istnieje StudyName
	SELECT Name FROM Studies where Name = @studyName;
	IF @@ROWCOUNT <= 0
		RAISERROR(15600, -1, -1, 'Given study name doesnt exist');

	-- spr czy w tabeli Enrollment istnieja studenci z podanego semestru
	SELECT * FROM Enrollment
	WHERE Enrollment.Semester = @existingSemester
	AND IdStudy = (
		SELECT Studies.IdStudy FROM Studies WHERE Name = @studyName
	);
	IF @@ROWCOUNT <= 0 
		RAISERROR(15600, -1, -1, 'There are no students on given studies and semester');

	-- dopisanie studentow z danego kierunku na kolejny semestr
	UPDATE Enrollment SET Semester = @existingSemester + 1
	WHERE IdStudy = (SELECT Studies.IdStudy FROM Studies WHERE Name = @studyName)
	COMMIT
END
GO