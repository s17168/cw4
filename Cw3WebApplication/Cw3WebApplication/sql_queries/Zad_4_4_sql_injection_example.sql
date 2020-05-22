use [s17168]

--DROP TABLE Student;


select Student.FirstName, Student.LastName, Student.BirthDate, Studies.Name, Enrollment.Semester 
from 
Student inner join Enrollment 
on Student.IdEnrollment = Enrollment.IdEnrollment
inner join studies 
on Studies.IdStudy = Enrollment.IdStudy
where Student.IndexNumber = 's123'; drop table student; select * from student where FirstName = '';

