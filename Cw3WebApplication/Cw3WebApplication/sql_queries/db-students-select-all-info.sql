use [s17168]

select Student.FirstName, Student.LastName, Student.BirthDate, Studies.Name, Enrollment.Semester 
from 
Student inner join Enrollment 
on Student.IdEnrollment = Enrollment.IdEnrollment
inner join studies 
on Studies.IdStudy = Enrollment.IdStudy;
