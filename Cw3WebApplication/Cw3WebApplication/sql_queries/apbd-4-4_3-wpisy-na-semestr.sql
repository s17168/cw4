use [s17168]

--select * from student;

select Student.FirstName, Student.LastName, Student.IndexNumber, Student.BirthDate, Student.IdEnrollment, Studies.Name, Enrollment.Semester 
                    from Student inner join Enrollment on Student.IdEnrollment = Enrollment.IdEnrollment inner join studies 
                    on Studies.IdStudy = Enrollment.IdStudy;


--select * from enrollment;

-- [4.3]
-- Wpisy na semestr dla studenta o podanym id

select IndexNumber, Enrollment.IdEnrollment, Enrollment.Semester, Enrollment.IdStudy, Enrollment.StartDate 
from Student inner join Enrollment on Enrollment.idEnrollment = student.idEnrollment
where Student.IndexNumber = 's202001' ;