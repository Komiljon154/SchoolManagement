using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Entities;

public class Teacher
{
    public int TeacherID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Subject { get; set; }

    public ICollection<TeacherStudent> TeacherStudents { get; set; }
    public ICollection<TeacherClass> TeacherClasses { get; set; }
}
